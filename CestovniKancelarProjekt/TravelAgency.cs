
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TravelAgencyProject
{
    public class TravelAgency
    {

        public List<Trip> tripList;

        public TravelAgency()
        {

            tripList = new List<Trip>();
        }


        public void AddTrip(Trip trip)

        {

            if (tripList.Any(v => v.TripId == trip.TripId))
            {
                Console.WriteLine("Tento zájezd je již zadán.");
            }
            else
            {
                tripList.Add(trip);
            }
        }

        public void RemoveTrip(Trip trip)
        {
            if (tripList.Contains(trip))
            {
                tripList.Remove(trip);
                Console.WriteLine($"Zájezd ID {trip.TripId} s názvem {trip.TripName} byl úspěšně odstraněn.");

            }
            else
            {
                Console.WriteLine("Zájezd nebyl nalezen.");

            }
        }

        public void ShowTrips()
        {
            if (tripList.Count > 0)
            {

                Console.WriteLine("Název zájezdu - Destinace - Odjezd - Příjezd - ID zájezdu");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine();
                foreach (Trip trip in tripList)
                {

                    Console.WriteLine($"{trip.TripName} | {trip.Destination} | {trip.DepartureDate} | {trip.ArrivalDate} | {trip.TripId}");
                }
            }
            else
            {
                Console.WriteLine("Nejsou zde žádné zájezdy.");
            }

        }

        public void TripsYouCanDelete()
        {
            Console.WriteLine("Seznam dostupných zájezdů: ");
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            Console.WriteLine(" -ID- | Název");
            foreach (Trip trip in tripList)
            {

                Console.WriteLine($"{trip.TripId} | {trip.TripName}");
            }
        }

        public Trip FindTripWithId(string tripId)
        {

            Trip trip = tripList.Find(v => v.TripId == tripId);
            return trip;

        }

        public void SaveDataToFile(string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Trip z in tripList)
            {
                lines.Add($"{z.TripName},{z.Destination},{z.DepartureDate},{z.ArrivalDate},{z.TripId}");
            }
            File.WriteAllLines(fileName, lines);

        }

        public void LoadDataFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                tripList.Clear();
                string[] lines = File.ReadAllLines(fileName);
                foreach (string r in lines)
                {
                    string[] units = r.Split(",");

                    DateTime.TryParse(units[2], out DateTime departureDate);
                    DateTime.TryParse(units[3], out DateTime arrivalDate);

                    tripList.Add(new Trip(units[0], units[1], departureDate, arrivalDate, units[4]));
                }
            }
        }
    }

}

