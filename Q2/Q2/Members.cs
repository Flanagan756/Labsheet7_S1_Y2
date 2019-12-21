using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Labsheet7_Q2
{
    class Members
    {
        //Propeties
        public string MemberType { get; set; }
        public string Name { get; set; }
        public DateTime Joined  { get; set; }

        //Constructors

        //Methods
        public override string ToString()
        {
            return $"{Name} {MemberType} {Joined}";
        }

    }
}
