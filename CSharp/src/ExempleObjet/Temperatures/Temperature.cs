using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperatures
{
    class Temperature
    {
        private double _temperature;

        public double TemperatureCelsius
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public double TemperatureKelvin
        {
            get { return (_temperature + 273.15d); }
            set { _temperature = value - 273.15d; }
        }
    }
}
