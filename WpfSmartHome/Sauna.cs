using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSmartHome
{
    internal class Sauna
    {
        public Boolean SaunaSwitched { get; set; }
        public Boolean SaunaSwitched2 { get; set; }
        public int SaunaTemperature { get; set; }
        public void SaunaOn()
        {
            SaunaTemperature++;
            SaunaSwitched = true;
        }
        public void SaunaOff() 
        {
            SaunaTemperature--;
            SaunaSwitched = false;
        }
    }
}
