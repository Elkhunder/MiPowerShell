using System.Diagnostics;

namespace MiPowerShell.Handlers.Events
{
    public class ComboBox_IndexChanged
    {
        public void ComboBox_PrinterSelection_IndexChanged(object? sender, EventArgs e)
        {
            ComboBox comboBox = new();

            if (sender != null)
            {
                comboBox = (ComboBox)sender;
            }
            else
            {
                return;
            }

            Console.WriteLine($"Index Changed: {comboBox.SelectedItem}");
            Debug.WriteLine($"Index Changed: {comboBox.SelectedItem}");
        }
    }
}
