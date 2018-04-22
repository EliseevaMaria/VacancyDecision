using System;

namespace Model.Entity
{
    public class Expert : BaseNamedEntity
    {
        public int ExpertId
        {
            set;
            get;
        }

        public override int Id => this.ExpertId;

        public int Weight
        {
            set;
            get;
        }

        public string Description
        {
            set;
            get;
        }
    }
}
