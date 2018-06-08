using System;
using System.Collections.Generic;
using Database.Repository;
using Model;
using Model.Entity;

namespace Business
{
    public abstract class BaseComparison
    {
        protected AlternativeRepository alternativeRepository;

        protected Dictionary<string, Dictionary<string, int>> WinAmounts
        {
            get;
            private set;
        }

        public BaseComparison()
        {
            this.alternativeRepository = new AlternativeRepository();
        }

        public Alternative Compare(List<CollectiveComparisonAlternativePair> comparisonPairs)
        {
            List<Alternative> alternatives = this.alternativeRepository.GetRecords();
            this.InitializeAlternativesComparisonStructure(alternatives);
            this.FillAlternativesComparisonStructure(comparisonPairs);

            return this.Compare(comparisonPairs, alternatives);
        }

        protected abstract Alternative Compare(List<CollectiveComparisonAlternativePair> comparisonPairs, List<Alternative> alternatives);

        protected void FillAlternativesComparisonStructure(List<CollectiveComparisonAlternativePair> alternativePairs)
        {
            foreach (var pair in alternativePairs)
            {
                if (pair.Winner == pair.Alternative1)
                    this.WinAmounts[pair.Alternative1.Name][pair.Alternative2.Name]++;
                else if (pair.Winner == pair.Alternative2)
                    this.WinAmounts[pair.Alternative2.Name][pair.Alternative1.Name]++;
                else
                    throw new Exception("The winner doesn't belong to the alternative pair.");
            }
        }

        protected Dictionary<string, Dictionary<string, int>> InitializeAlternativesComparisonStructure(List<Alternative> alternatives)
        {
            this.WinAmounts = new Dictionary<string, Dictionary<string, int>>();
            foreach (var alternative in alternatives)
                this.WinAmounts.Add(alternative.Name, new Dictionary<string, int>());

            foreach (var alternativeDict in this.WinAmounts)
                foreach (var alternative in alternatives)
                    if (alternativeDict.Key == alternative.Name)
                        alternativeDict.Value.Add(alternative.Name, int.MaxValue);
                    else
                        alternativeDict.Value.Add(alternative.Name, 0);

            return this.WinAmounts;
        }
    }
}