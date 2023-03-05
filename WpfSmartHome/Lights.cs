using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSmartHome
{
    internal class Lights
    {
        public string Dimmer { get; set; }
        public Boolean Switched { get; set; }
        public Boolean Switched2 { get; set; }
        public void LightOn()
        {
            Switched = true;
        }

        public void LightOff()
        {
            Switched2 = false;
        }
    }
}
