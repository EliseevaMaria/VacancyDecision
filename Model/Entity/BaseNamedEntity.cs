using System;

namespace Model.Entity
{
    public abstract class BaseNamedEntity : BaseEntity
    {
        public string Name
        {
            set;
            get;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
