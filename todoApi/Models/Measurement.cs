using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DipsApi.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public string OverPressure { get; set; }
        public string UnderPressure { get; set; }
        public string MeasurementDate { get; set; }

        //public DateTime MeasurementDate { get; set; }
    }
}
