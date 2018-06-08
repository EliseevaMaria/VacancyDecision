using System;
using Model.Entity;

namespace Model
{
    public sealed class CollectiveComparisonAlternativePair
    {
        public Alternative Alternative1
        {
            get;
        }

        public Alternative Alternative2
        {
            get;
        }

        public CollectiveComparisonAlternativePair(Alternative alternative1, Alternative alternative2)
        {
            this.Alternative1 = alternative1;
            this.Alternative2 = alternative2;
        }

        public Alternative Winner
        {
            get;
            set;
        }
    }
}
