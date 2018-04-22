using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel.CustomControls.EntityFields;

namespace VacationDecision.CustomControls.EntityFields
{
    /// <summary>
    /// Interaction logic for MarkFields.xaml
    /// </summary>
    public partial class MarkFields : UserControl
    {
        public MarkFields()
        {
            InitializeComponent();
        }

        private void NumericValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
