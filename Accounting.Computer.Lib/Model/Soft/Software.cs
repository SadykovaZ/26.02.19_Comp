using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib.Model.Soft
{
    public enum TypeSoftware {free, share }
    public struct Software
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime InstallDate { get; set; }
        public TypeSoftware typeSoftware { get; set; }
        public Equipment equipment { get; set; }

    }
}
