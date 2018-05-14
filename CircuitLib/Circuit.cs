using System;
using System.Collections.Generic;
using System.Text;

namespace CktMgr.CircuitLib
{
    public class Circuit
    {
        public int Id { get; set; }
        // Region new with May2018
        public string Region { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        // LAT and LON new with May2018
        public string LAT { get; set; }
        public string LON { get; set; }

        public string DeliveryMethod { get; set; }
        // tier removed with May2018
        // public string Tier { get; set; }

        // public string HighestSpeed { get; set; }
        // speed new with May2018
        public string Speed { get; set; }

        public string Term { get; set; }
        // MRR and NRR new with May2018
        public string MRR { get; set; }
        public string NRR { get; set; }

        public override string ToString()
        {
            return $"{Address} {City}";
        }
    }
}
