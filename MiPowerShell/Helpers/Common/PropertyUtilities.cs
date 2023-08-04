namespace MiPowerShell.Helpers.Common
{
    public class PropertyUtilities
    {
        private static void SetField<T>(ref T field, T value) where T : Control
        {
            if (field == null)
            {
                field = value;
            }
        }
    }
}
