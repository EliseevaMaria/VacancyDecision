using System;
using Model.Entity;

namespace Model
{
    public class AlternativeToCompare
    {
        public Alternative Alternative
        {
            get;
            set;
        }

        public AlternativeToCompare(Alternative alternative, bool isCompared = false)
        {
            this.Alternative = alternative;
            this.IsCompared = isCompared;
        }

        public bool IsCompared
        {
            get;
            set;
        }
    }
}
