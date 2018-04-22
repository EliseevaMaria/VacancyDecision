using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace VacationDecision.CustomControls.EntityFields
{
    /// <summary>
    /// Interaction logic for CriterionFields.xaml
    /// </summary>
    public partial class CriterionFields : UserControl
    {
        public CriterionFields()
        {
            InitializeComponent();
        }

        private void NumericValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
