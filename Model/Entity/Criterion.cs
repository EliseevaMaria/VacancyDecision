using System;
using Model.Enumeration;

namespace Model.Entity
{
    public class Criterion : BaseNamedEntity
    {
        public int CriterionId
        {
            set;
            get;
        }

        public override int Id => this.CriterionId;

        public int Range
        {
            set;
            get;
        }

        public int Weight
        {
            set;
            get;
        }

        public CriterionType Type
        {
            set;
            get;
        }

        public CriterionOptimalValue OptimalValue
        {
            set;
            get;
        }

        public string Unit
        {
            set;
            get;
        }

        public CriterionScaleType ScaleType
        {
            set;
            get;
        }
    }
}
