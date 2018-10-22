using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataProtocol
{
    public class BasicFood
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public Uri Photo { get; set; }
        public String ServingUnits { get; set; }
    }
}
