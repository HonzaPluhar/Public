using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyProject
{
    public class Trip
    {

        public string TripName;
        public string Destination;
        public DateTime DepartureDate;
        public DateTime ArrivalDate;
        public string TripId;


        public Trip(string tripName, string destination, DateTime departureDate, DateTime arrivalDate, string tripId)
        {
            TripName = tripName;
            Destination = destination;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            TripId = tripId;
        }

    }
}
