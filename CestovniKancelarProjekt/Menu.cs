using TravelAgencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TravelAgencyProject
{
    public class Menu
    {

        TravelAgency travelAgency = new TravelAgency();

        public Menu()
        {
            travelAgency = new TravelAgency();
            travelAgency.LoadDataFromFile("data.txt");
        }
        public void MainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Cestovní kancelář C# projekt ");
                Console.WriteLine("Jan Pluhar - github.com/HonzaPluhar ");
                Console.WriteLine();
                Console.WriteLine("1 - Přidat zájezd");
                Console.WriteLine("2 - Odebrat zájezd");
                Console.WriteLine("3 - Zobrazit všechny zájezdy");
                Console.WriteLine("4 - Vyhledat zájezd podle ID");
                Console.WriteLine("0 - Ukončit program");


                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        TripAdd();
                        break;
                    case "2":
                        TripRemove();
                        break;
                    case "3":
                        ShowAll();
                        break;
                    case "4":
                        TripSearch();
                        break;
                    case "0":
                        travelAgency.SaveDataToFile("data.txt");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Neexistující příkaz.");
                        ContinueWithKey();
                        break;

                }

            }
        }

        public void TripAdd()
        {
            Console.Clear();
            Console.Write("Zadejte název zájezdu: ");
            string name = Console.ReadLine();


            Console.Write("Zadejte destinaci: ");
            string destination = Console.ReadLine();




            DateTime departureDate;
            while (true)
            {
                Console.Write("Datum odjezdu (dd.MM.yyyy): ");
                string departureDateString = Console.ReadLine();
                if (DateTime.TryParse(departureDateString, out departureDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatný formát data, zadejte prosím znovu.");
                }
            }





            DateTime arrivalDate;
            while (true)
            {
                Console.Write("Datum příjezdu (dd.MM.yyyy): ");
                string arrivalDateString = Console.ReadLine();
                if (DateTime.TryParse(arrivalDateString, out arrivalDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatný formát data, zadejte prosím znovu.");
                }
            }


            string tripId = Guid.NewGuid().ToString().ToLower().Substring(0, 4);

            Trip trip = new Trip(name, destination, departureDate, arrivalDate, tripId);
            travelAgency.AddTrip(trip);

            Console.WriteLine($"Zájezd ID {trip.TripId} s názvem {trip.TripName} byl úspěšně přidán do seznamu zájezdů.");
            ContinueWithKey();



        }

        public void TripRemove()
        {
            Console.Clear();
            travelAgency.TripsYouCanDelete();
            Console.WriteLine();
            Console.Write("Zadejte ID zájezdu který chcete odstranit: ");

            string tripId = Console.ReadLine().ToLower();



            Trip trip = travelAgency.tripList.Find(v => v.TripId == tripId);

            if (trip != null)
            {
                travelAgency.RemoveTrip(trip);
                ContinueWithKey();
            }
            else
            {
                Console.WriteLine("Zájezd s tímto ID nebyl nalezen.");
                ContinueWithKey();
            }

        }

        public void ShowAll()
        {
            Console.Clear();
            travelAgency.ShowTrips();
            ContinueWithKey();
        }

        public void TripSearch()
        {
            Console.Clear();
            Console.Write("Zadejte ID zájezdu pro vyhledání: ");
            string tripId = Console.ReadLine().ToLower();

            Trip trip = travelAgency.FindTripWithId(tripId);

            {
                if (trip != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Zájezd ID {trip.TripId} byl nalezen.");
                    Console.WriteLine();
                    Console.WriteLine("Informace o zájezdu:");
                    Console.WriteLine($"Název zájezdu: {trip.TripName}");
                    Console.WriteLine($"Destinace: {trip.Destination}");
                    Console.WriteLine($"Od / Do: {trip.DepartureDate} / {trip.ArrivalDate}");
                    ContinueWithKey();
                }
                else
                {
                    Console.WriteLine("Zájezd s tímto ID nebyl nalezen.");
                    ContinueWithKey();
                }
            }

        }




        public void ContinueWithKey()
        {
            Console.WriteLine();
            Console.WriteLine("Pro pokračování stiskněte libovolnou klávesu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
