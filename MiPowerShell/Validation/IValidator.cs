using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MiPowerShell.Validation
{
    public interface IValidator
    {

        public ValidationResult Validate(object sender, CancelEventArgs e, ref string propertyName, ref string pattern)
        { 
        
            TextBox textBox = (TextBox)sender;
            ValidationResult validationResult;

            validationResult = ValidateInput(textBox, ref propertyName);
            if (!validationResult.isValid)
            {
                return validationResult;
            }
            validationResult = ValidateFormat(textBox, ref propertyName, ref pattern);
            if (!validationResult.isValid)
            {
                return validationResult;
            }
            else
            {
                return new ValidationResult
                {
                    isValid= true,
                    errorMessage= String.Empty,
                };
            }
        }

        ValidationResult ValidateInput(TextBox textBox, ref string propertyName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                return new ValidationResult
                {
                    isValid = false,
                    errorMessage = $"{propertyName} can not be empty"
                };
            }

            return new ValidationResult
            {
                isValid = true,
                errorMessage = String.Empty
            };
        }

        ValidationResult ValidateLength(TextBox textBox, ref int length, ref string propertyName)
        {
            if (textBox.Text.Length != length)
            {
                return new ValidationResult
                {
                    isValid = false,
                    errorMessage = $"{propertyName} can only be {length} characters long"
                };
            }
            return new ValidationResult
            {
                isValid = true,
                errorMessage = String.Empty
            };
        }

        ValidationResult ValidateFormat(TextBox textBox, ref string propertyName, ref string pattern)
        {
            Match match = Regex.Match(textBox.Text, pattern);
            if (!match.Success)
            {
                return new ValidationResult
                {
                    isValid = false,
                    errorMessage = $"{propertyName} format is incorrect"
                };
            }
            return new ValidationResult
            {
                isValid = true,
                errorMessage = String.Empty
            };
        }
    }
}
