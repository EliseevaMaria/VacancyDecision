using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Model.Entity;

namespace Database.Repository
{
    public class VectorRepository : BaseRepository<Vector>
    {
        protected override List<Vector> ExecuteQuery(IDbConnection connection, string sql)
        {
            var result = connection.Query<Vector, Mark, Alternative, Criterion, Vector>(sql, (vector, mark, alternative, criterion) =>
            {
                mark.Criterion = criterion;
                vector.Mark = mark;
                vector.Alternative = alternative;
                vector.Criterion = mark.Criterion.Name;
                return vector;
            }, splitOn: "MarkId, AlternativeId, CriterionId").ToList();

            return result;
        }

        protected override string GetFieldsForInsertion()
        {
            return "Vector.MarkId, Vector.AlternativeId";
        }

        protected override string GetInnerJoinClauses()
        {
            return @"INNER JOIN Mark ON Mark.MarkId = Vector.MarkId
                     INNER JOIN Alternative ON Alternative.AlternativeId = Vector.AlternativeId
                     INNER JOIN Criterion ON Criterion.CriterionId = Mark.CriterionId";
        }

        public List<Mark> GetMarks()
        {
            var markRepository = new MarkRepository();
            return markRepository.GetRecords();
            //string sql = "SELECT * FROM Mark";

            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            //{
            //    return connection.Query<Mark>(sql).ToList();
            //}
        }

        public List<Alternative> GetAlternatives()
        {
            var alternativeRepository = new AlternativeRepository();
            return alternativeRepository.GetRecords();
            //string sql = "SELECT * FROM Alternative";

            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            //{
            //    return connection.Query<Alternative>(sql).ToList();
            //}
        }

        protected override string GetFieldsForUpdating()
        {
            return "Vector.MarkId = @MarkId, Vector.AlternativeId = @AlternativeId";
        }

        protected override string GetValuesForInsertion(Vector entity)
        {
            return $"{entity.Mark.MarkId}, {entity.Alternative.AlternativeId}";
        }

        protected override object GetValuesForUpdating(Vector entity)
        {
            return new
            {
                entity.Mark.MarkId,
                entity.Alternative.AlternativeId
            };
        }
    }
}
