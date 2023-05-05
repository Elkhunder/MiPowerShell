using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Validation
{
    public class ValidationResult
    {
        public bool isValid { get; set; }
        public string? errorMessage { get; set; }
    }
}
