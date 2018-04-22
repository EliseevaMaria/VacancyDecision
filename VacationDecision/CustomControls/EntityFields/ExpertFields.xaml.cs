using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace VacationDecision.CustomControls.EntityFields
{
    /// <summary>
    /// Interaction logic for ExpertFields.xaml
    /// </summary>
    public partial class ExpertFields : UserControl
    {
        public ExpertFields()
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
