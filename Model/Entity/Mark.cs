using System;

namespace Model.Entity
{
    public class Mark : BaseNamedEntity
    {
        public int MarkId
        {
            set;
            get;
        }

        public override int Id => this.MarkId;

        public Criterion Criterion
        {
            set;
            get;
        }
        
        public int Rank
        {
            set;
            get;
        }

        public int QuantitativeValue
        {
            set;
            get;
        }

        public int NormalizedValue
        {
            set;
            get;
        }
    }
}
