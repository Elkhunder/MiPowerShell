using MiPowerShell.Arguments;

namespace MiPowerShell.Helpers
{
    internal interface ICommandHandler
    {
        bool ValidateArguments(CommandArguments arguments);
        void Handle(CommandArguments arguments, DataGridView dataGridView);
    }
}
