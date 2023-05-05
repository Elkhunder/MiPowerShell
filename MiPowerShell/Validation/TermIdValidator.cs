using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MiPowerShell.Validation
{
    internal class TermIdValidator
    {
        ErrorProvider _errorProvider;
        public TermIdValidator(ErrorProvider errorProvider) 
        {
           _errorProvider= errorProvider;
        }
        public void Validate(object sender, CancelEventArgs e)
        {
            string errorMessage = String.Empty;
            TextBox textBox = (TextBox)sender;
            string pattern = @"^.{1,8}(,.*){0,}$";
            string propertyName = "Term ID";

            IValidator validator = new Validator();

            ValidationResult validationResult = validator.Validate(sender, e, ref propertyName, ref pattern);

            _errorProvider.SetError(textBox, validationResult.errorMessage);
        }
    }
}

