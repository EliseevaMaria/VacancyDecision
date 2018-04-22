using System;

namespace Model.Entity
{
    public class Alternative : BaseNamedEntity
    {
        public int AlternativeId
        {
            set;
            get;
        }

        public override int Id => this.AlternativeId;
    }
}
