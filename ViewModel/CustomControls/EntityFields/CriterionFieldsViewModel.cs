using System;
using Model.Entity;
using Model.Enumeration;

namespace ViewModel.CustomControls.EntityFields
{
    public class CriterionFieldsViewModel : EntityFieldsViewModel
    {
        string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value)
                    return;

                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }

        string range;
        public string Range
        {
            get
            {
                return this.range;
            }
            set
            {
                if (this.range == value)
                    return;

                this.range = value;
                this.OnPropertyChanged(nameof(this.Range));
            }
        }

        string weight;
        public string Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (this.weight == value)
                    return;

                this.weight = value;
                this.OnPropertyChanged(nameof(this.Weight));
            }
        }

        CriterionType? type;
        public CriterionType? Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type == value)
                    return;

                this.type = value;
                this.OnPropertyChanged(nameof(this.Type));
            }
        }

        CriterionOptimalValue? optimalValue;
        public CriterionOptimalValue? OptimalValue
        {
            get
            {
                return this.optimalValue;
            }
            set
            {
                if (this.optimalValue == value)
                    return;

                this.optimalValue = value;
                this.OnPropertyChanged(nameof(this.OptimalValue));
            }
        }

        string unit;
        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                if (this.unit == value)
                    return;

                this.unit = value;
                this.OnPropertyChanged(nameof(this.Unit));
            }
        }

        CriterionScaleType? scaleType;
        public CriterionScaleType? ScaleType
        {
            get
            {
                return this.scaleType;
            }
            set
            {
                if (this.scaleType == value)
                    return;

                this.scaleType = value;
                this.OnPropertyChanged(nameof(this.ScaleType));
            }
        }
    }
}
