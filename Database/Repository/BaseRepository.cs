using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Model.Entity;

namespace Database.Repository
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        public void Delete(T entity)
        {
            string sql = $"DELETE FROM {this.TableName} WHERE {this.TableName}Id = {entity.Id}";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            {
                connection.Query<T>(sql);
            }
        }

        protected virtual List<T> ExecuteQuery(IDbConnection connection, string sql)
        {
            return connection.Query<T>(sql).ToList();
        }

        public int? CreateRecord(T entity)
        {
            string sql = $@"INSERT INTO {this.TableName} ({this.GetFieldsForInsertion()})
                                    VALUES ({this.GetValuesForInsertion(entity)});
                            SELECT CAST(@@IDENTITY as int);";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            {
                int? entityId = connection.Query<int>(sql).FirstOrDefault();
                return entityId;
            }
        }

        protected abstract string GetFieldsForInsertion();

        protected abstract string GetFieldsForUpdating();

        protected virtual string GetInnerJoinClauses()
        {
            return string.Empty;
        }

        public T GetRecordById(int id)
        {
            string sql = $@"SELECT * FROM {this.TableName} {this.GetInnerJoinClauses()} 
                            WHERE {this.TableName}Id = {id}";
            
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            {
                T record = this.ExecuteQuery(connection, sql).FirstOrDefault();
                return record;
            }
        }

        public List<T> GetRecords(string where = "")
        {
            string sql = $"SELECT * FROM {this.TableName} {this.GetInnerJoinClauses()} {where}";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            {
                var records = this.ExecuteQuery(connection, sql);
                return records;
            }
        }

        public int GetRecordsCount(string where = "")
        {
            string sql = $"SELECT COUNT(*) FROM {this.TableName} {where}";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            {
                int count = connection.QuerySingle<int>(sql);
                return count;
            }
        }

        protected abstract string GetValuesForInsertion(T entity);

        protected abstract object GetValuesForUpdating(T entity);

        private string tableName;
        private string TableName => tableName ?? (tableName = typeof(T).Name);

        public void UpdateRecord(T entity)
        {
            string sql = $@"UPDATE {this.TableName} SET {this.GetFieldsForUpdating()} 
                            WHERE {this.TableName}Id = {entity.Id}";
            var param = this.GetValuesForUpdating(entity);

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            {
                connection.Query<T>(sql, param);
            }
        }
    }
}
