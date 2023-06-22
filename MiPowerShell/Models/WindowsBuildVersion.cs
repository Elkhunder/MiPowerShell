using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    internal class WindowsBuildVersion
    {
        private readonly Dictionary<string, string> _buildToVersionMap = new()
        {
            { "10240", "1507" },
            { "10586", "1511" },
            { "14393", "1607" },
            { "15063", "1703" },
            { "16299", "1709" },
            { "17134", "1803" },
            { "17763", "1809" },
            { "18362", "1903" },
            { "18363", "1909" },
            { "19041", "2004" },
            { "19042", "20H2" },
            { "19043", "21H1" },
            { "19044", "21H2" },
            { "19045", "22H2" }
        };
        public WindowsBuildVersion()
        {
            
        }

        public string GetVersionByBuildNumber(string buildNumber)
        {
            Dictionary<string, string> buildNumberToVersionMap = new()
            {
                { "10240", "1507" },
                { "10586", "1511" },
                { "14393", "1607" },
                { "15063", "1703" },
                { "16299", "1709" },
                { "17134", "1803" },
                { "17763", "1809" },
                { "18362", "1903" },
                { "18363", "1909" },
                { "19041", "2004" },
                { "19042", "20H2" },
                { "19043", "21H1" },
                { "19044", "21H2" },
                { "19045", "22H2" }
            };
            if (buildNumber == null || !buildNumberToVersionMap.ContainsKey(buildNumber))
            {
                return $"Couldn't locate a version for the provided build number: {buildNumber}";
            }
            return buildNumberToVersionMap[buildNumber];
        }
    }
}
