using System;
using Model.Entity;

namespace Database.Repository
{
    public sealed class ExpertRepository : BaseRepository<Expert>
    {
        protected override string GetFieldsForInsertion()
        {
            return "Name, Description, Weight";
        }

        protected override string GetFieldsForUpdating()
        {
            return @"Name = @Name, Description = @Description, Weight = @Weight";
        }

        protected override string GetValuesForInsertion(Expert entity)
        {
            return $"'{entity.Name}', '{entity.Description}', {entity.Weight}";
        }

        protected override object GetValuesForUpdating(Expert entity)
        {
            return new { entity.Name, entity.Description, entity.Weight };
        }
    }
}
