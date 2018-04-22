using System;
using Model.Entity;

namespace Database.Repository
{
    public class ResultRepository : BaseRepository<Result>
    {
        protected override string GetFieldsForInsertion()
        {
            throw new NotImplementedException();
        }

        protected override string GetFieldsForUpdating()
        {
            throw new NotImplementedException();
        }

        protected override string GetValuesForInsertion(Result entity)
        {
            throw new NotImplementedException();
        }

        protected override object GetValuesForUpdating(Result entity)
        {
            throw new NotImplementedException();
        }
    }
}
