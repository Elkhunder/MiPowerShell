using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    public class SoftwareInformation
    {
        public List<Software>? InstalledSoftware { get; set; }
        public bool IsInitialized = false;
        public SoftwareInformation()
        {
            InstalledSoftware = new List<Software>();
        }
    }

    public class Software : IComparable<Software>, IEquatable<Software>
    {
        public Software(string name, Version version, string publisher, string installDate)
        {
            Name = name;
            Version = version;
            Publisher = publisher;
            InstallDate = installDate;
        }

        public string Name { get; set; }
        public Version Version { get; set; }
        public string Publisher { get; set; }
        public string InstallDate { get; set; }

        public int CompareTo(Software? other)
        {
            if (other == null) return 1;
            if (this.Name == null) return -1;

            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(Software? other)
        {
            if (other == null)
            {
                return false;
            }

            // Modify this as needed. You might want to compare other fields as well.
            return this.Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Software softwareObj = obj as Software;
            if (softwareObj == null)
            {
                return false;
            }
            else
            {
                return Equals(softwareObj);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
