using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfSmartHome
{
    internal class Thermostat
    {
        public int Temperature { get; set; }
        private int temperature;
        public void SetTemperature(int UserInputTemperature)
        {
            if ((UserInputTemperature >= 0) && (UserInputTemperature <= 40))
            {
                temperature = UserInputTemperature;
            }
            else
            {
                temperature = 0;
                throw new ArgumentOutOfRangeException();
            }
        }
        public int GetTemperature()
        {
            return temperature;
        }
    }
}
