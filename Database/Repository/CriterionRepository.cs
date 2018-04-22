using System;
using Model.Entity;

namespace Database.Repository
{
    public sealed class CriterionRepository : BaseRepository<Criterion>
    {
        protected override string GetFieldsForInsertion()
        {
            return "Name, Range, Weight, Type, OptimalValue, Unit, ScaleType";
        }

        protected override string GetFieldsForUpdating()
        {
            return @"Name = @Name, Range = @Range, Weight = @Weight, Type = @Type, 
                    OptimalValue = @OptimalValue, Unit = @Unit, ScaleType = @ScaleType";
        }

        protected override string GetValuesForInsertion(Criterion entity)
        {
            return $@"'{entity.Name}', {entity.Range}, {entity.Weight}, {(byte)entity.Type}, 
                      {(byte)entity.OptimalValue}, '{entity.Unit}', {(byte)entity.ScaleType}";
        }

        protected override object GetValuesForUpdating(Criterion entity)
        {
            return new
            {
                entity.Name,
                entity.Range,
                entity.Weight,
                entity.Type,
                entity.OptimalValue,
                entity.Unit,
                entity.ScaleType
            };
        }
    }
}
