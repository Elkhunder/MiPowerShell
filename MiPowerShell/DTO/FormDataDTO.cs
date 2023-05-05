using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.DTO
{
    internal class FormDataDTO
    {
        public TextBox? FirstNameTextBox { get; set; }
        public TextBox? LastNameTextBox { get; set; }
        public ComboBox? GenderComboBox { get; set; }
        public DateTimePicker? BirthdatePicker { get; set; }
        public Dictionary<string, object> DynamicProperties { get; set; }
        // ... other properties

        public FormDataDTO()
        {
            DynamicProperties = new Dictionary<string, object>();
        }
        public void AddFormObject(string key, object value)
        {
            switch (key)
            {
                case "FirstNameTextBox":
                    FirstNameTextBox = (TextBox)value;
                    break;
                case "LastNameTextBox":
                    LastNameTextBox = (TextBox)value;
                    break;
                // ... other cases
                default:
                    throw new ArgumentException("Invalid key", nameof(key));
            }
        }
        public void UpdateFormObject(string key, object value)
        {
            switch (key)
            {
                case "FirstNameTextBox":
                    FirstNameTextBox = (TextBox)value;
                    break;
                case "LastNameTextBox":
                    LastNameTextBox = (TextBox)value;
                    break;
                // ... other cases
                default:
                    throw new ArgumentException("Invalid key", nameof(key));
            }
        }
        public void RemoveFormObject(string key)
        {
            switch (key)
            {
                case "FirstNameTextBox":
                    FirstNameTextBox = null;
                    break;
                case "LastNameTextBox":
                    LastNameTextBox = null;
                    break;
                // ... other cases
                default:
                    throw new ArgumentException("Invalid key", nameof(key));
            }
        }
        public void ClearDynamicProperties()
        {
            DynamicProperties.Clear();
        }
        public void ClearAll()
        {
            FirstNameTextBox = null;
            LastNameTextBox = null;
            GenderComboBox = null;
            BirthdatePicker = null;
            // ... other properties
        }
    }
}
