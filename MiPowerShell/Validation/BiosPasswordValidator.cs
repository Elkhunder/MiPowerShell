using MiPowerShell.Controls;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MiPowerShell.Validation
{
    internal class BiosPasswordValidator
    {
        ErrorProvider _errorProvider;

        public BiosPasswordValidator(ErrorProvider errorProvider)
        {
            _errorProvider= errorProvider;
        }

        public void Validate(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string pattern = @"^[a-zA-Z]{4}\d{4}$";
            string propertyName = "Bios Password";

            IValidator validator = new Validator();

            ValidationResult validationResult = validator.Validate(sender, e, ref propertyName, ref pattern);
           

            _errorProvider.SetError(textBox, validationResult.errorMessage);
        }
        
    }
}
