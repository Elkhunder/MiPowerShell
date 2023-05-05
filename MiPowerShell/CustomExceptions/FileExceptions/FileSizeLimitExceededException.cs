using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.CustomExceptions.FileExceptions
{
    public class FileSizeLimitExceededException : Exception
    {
        public FileSizeLimitExceededException()
        {
        }

        public FileSizeLimitExceededException(string message)
            : base(message)
        {
        }

        public FileSizeLimitExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
