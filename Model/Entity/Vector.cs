using System;

namespace Model.Entity
{
    public class Vector : BaseEntity
    {
        public int VectorId
        {
            get;
            set;
        }

        public override int Id => this.VectorId;

        public Alternative Alternative
        {
            get;
            set;
        }

        public string Criterion
        {
            get;
            set;
        }

        public Mark Mark
        {
            get;
            set;
        }
    }
}
