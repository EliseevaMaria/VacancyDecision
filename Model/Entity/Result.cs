using System;

namespace Model.Entity
{
    public class Result : BaseEntity
    {
        public int ResultId
        {
            set;
            get;
        }
        public override int Id => this.ResultId;

        public Expert Expert
        {
            set;
            get;
        }

        public Alternative Alternative
        {
            set;
            get;
        }

        public int Rank
        {
            set;
            get;
        }

        public int Weight
        {
            set;
            get;
        }
    }
}
