using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Entity;

namespace Business
{
    public class SimpsonComparison : BaseComparison
    {
        protected override Alternative Compare(List<CollectiveComparisonAlternativePair> comparisonPairs, List<Alternative> alternatives)
        {
            var voteMinAmounts = new Dictionary<string, int>();
            foreach (var alternative in alternatives)
                voteMinAmounts.Add(alternative.Name, int.MaxValue);

            foreach (var alternativeColumn in this.WinAmounts)
                voteMinAmounts[alternativeColumn.Key] = alternativeColumn.Value.Min(x => x.Value);

            int maxAmount = 0;
            string bestAlternativeName = null;
            foreach (var voteAmount in voteMinAmounts)
            {
                if (maxAmount < voteAmount.Value)
                {
                    maxAmount = voteAmount.Value;
                    bestAlternativeName = voteAmount.Key;
                }
            }
            return alternatives.SingleOrDefault(x => x.Name == bestAlternativeName);
        }
    }
}
