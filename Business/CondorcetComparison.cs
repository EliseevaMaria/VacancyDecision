using System;
using System.Collections.Generic;
using Model;
using Model.Entity;

namespace Business
{
    public class CondorcetComparison : BaseComparison
    {
        protected override Alternative Compare(List<CollectiveComparisonAlternativePair> comparisonPairs, List<Alternative> alternatives)
        {
            foreach (var alternativeColumn in alternatives)
            {
                int wins = 0;
                foreach (var alternative in alternatives)
                {
                    if (alternative == alternativeColumn)
                        continue;

                    if (this.WinAmounts[alternativeColumn.Name][alternative.Name] > this.WinAmounts[alternative.Name][alternativeColumn.Name])
                        wins++;
                }

                if (wins == alternatives.Count - 1)
                    return alternativeColumn;
            }

            return null;
        }
    }
}
