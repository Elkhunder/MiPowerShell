using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.CustomExceptions.FileExceptions
{
    public class FileEmptyException : Exception
    {
        public FileEmptyException() { }

        public FileEmptyException(string message)
            : base(message)
        {
        }

        public FileEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
