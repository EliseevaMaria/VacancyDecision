﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Model.Entity;

namespace Database.Repository
{
    public sealed class MarkRepository : BaseRepository<Mark>
    {
        protected override List<Mark> ExecuteQuery(IDbConnection connection, string sql)
        {
            var result = connection.Query<Mark, Criterion, Mark>(sql, (mark, criterion) =>
            {
                mark.Criterion = criterion;
                return mark;
            }, splitOn: "CriterionId").ToList();

            return result;
        }

        protected override string GetFieldsForInsertion()
        {
            return "Name, CriterionId, Rank, QuantitativeValue, NormalizedValue";
        }

        protected override string GetInnerJoinClauses()
        {
            return $"INNER JOIN Criterion ON Mark.CriterionId = Criterion.CriterionId";
        }

        protected override string GetFieldsForUpdating()
        {
            return @"Name = @Name, CriterionId = @CriterionId, Rank = @Rank,
                    QuantitativeValue = @QuantitativeValue, NormalizedValue = @NormalizedValue";
        }

        protected override string GetValuesForInsertion(Mark entity)
        {
            return $"'{entity.Name}', {entity.Criterion.Id}, {entity.Rank}, {entity.QuantitativeValue}, {entity.NormalizedValue}";
        }

        protected override object GetValuesForUpdating(Mark entity)
        {
            return new
            {
                entity.Name,
                entity.Criterion.CriterionId,
                entity.Rank,
                entity.QuantitativeValue,
                entity.NormalizedValue
            };
        }

        public List<Criterion> GetCriteria()
        {
            var criterionRepositpry = new CriterionRepository();
            return criterionRepositpry.GetRecords();
            //string sql = $"SELECT * FROM Criterion";

            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionString))
            //{
            //    return connection.Query<Criterion>(sql).ToList();
            //}
        }
    }
}
