using MiPowerShell.Arguments;
using MiPowerShell.Arguments.BiosCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers
{
    internal interface ICommandHandler
    {
        bool ValidateArguments(CommandArguments arguments);
        void Handle(CommandArguments arguments);
    }
}
