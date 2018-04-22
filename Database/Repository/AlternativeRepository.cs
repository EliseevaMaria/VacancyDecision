using System;
using Model.Entity;

namespace Database.Repository
{
    public sealed class AlternativeRepository : BaseRepository<Alternative>
    {
        protected override string GetFieldsForInsertion()
        {
            return "Name";
        }

        protected override string GetFieldsForUpdating()
        {
            return "Name = @Name";
        }

        protected override string GetValuesForInsertion(Alternative entity)
        {
            return $"'{entity.Name}'";
        }

        protected override object GetValuesForUpdating(Alternative entity)
        {
            return new { entity.Name };
        }
    }
}
