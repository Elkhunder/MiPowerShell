using MiPowerShell.Arguments;
using MiPowerShell.Handlers.Commands;

public class CommandDispatcher
{
    private readonly CommandHandlers? _commandHandlers;

    public CommandDispatcher()
    {
        _commandHandlers = new CommandHandlers();
    }

    public void Dispatch(string command, CommandArguments arguments, DataGridView dataGridView)
    {
        var handler = _commandHandlers?.GetHandler(command);

        if (!(bool)handler?.ValidateArguments(arguments)!)
        {
            // Add try catch block to pass the exception to the error handler or throw the exception into the error dispatcher class.
            throw new ArgumentException("Invalid arguments", nameof(arguments));
        }

        handler.Handle(arguments, dataGridView);
    }
}
