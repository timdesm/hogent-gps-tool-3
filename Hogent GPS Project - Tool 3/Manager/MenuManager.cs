using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogent_GPS_Project___Tool_3
{
    class MenuManager
    {
        public static void case1()
        {
            Program.printHeader();
            Console.WriteLine("----- [PROVINCIE LIST] -----");
            Console.WriteLine(" ");
            Console.WriteLine("Loading data...");
            Dictionary<int, String> states = DatabaseManager.GetStateList();
            Program.printHeader();
            Console.WriteLine("----- [PROVINCIE LIST] -----");
            Console.WriteLine(" ");
            foreach (int key in states.Keys)
                Console.WriteLine("[ID: " + key + "] " + states[key]);
            Console.WriteLine("");
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }

        public static void case2()
        {
            Boolean runLoop = true;
            while (runLoop)
            {
                Program.printHeader();
                Console.WriteLine("----- [PROVINCIE INFO] -----");
                Console.WriteLine("[1] Search on Name");
                Console.WriteLine("[2] Search on ID");
                Console.WriteLine("[3] Go back");
                Console.Write("Selection: ");
                String selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Program.printHeader();
                        Console.WriteLine("----- [PROVINCIE INFO] -----");
                        Console.Write("Search on Name: ");
                        String NameSearch = Console.ReadLine();
                        int ID = DatabaseManager.getStateID(NameSearch);
                        if (ID != 0)
                        {
                            String name = DatabaseManager.getStateName(ID);
                            int count = DatabaseManager.getCityCount(ID);
                            Program.printHeader();
                            Console.WriteLine("----- [PROVINCIE INFO] -----");
                            Console.WriteLine("ID: " + ID);
                            Console.WriteLine("Name: " + name);
                            Console.WriteLine("Cities: " + count);
                            Console.WriteLine(" ");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No provincie found with that name, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Program.printHeader();
                        Console.WriteLine("----- [PROVINCIE INFO] -----");
                        Console.Write("Search on ID: ");
                        int IdSearch = int.Parse(Console.ReadLine());

                        String name2 = DatabaseManager.getStateName(IdSearch);

                        if (name2 != "NULL")
                        {
                            int count = DatabaseManager.getCityCount(IdSearch);
                            Program.printHeader();
                            Console.WriteLine("----- [PROVINCIE INFO] -----");
                            Console.WriteLine("ID: " + IdSearch);
                            Console.WriteLine("Name: " + name2);
                            Console.WriteLine("Cities: " + count);
                            Console.WriteLine(" ");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No provincie found with that ID, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        runLoop = false;
                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void case3()
        {
            Boolean runLoop = true;
            while (runLoop)
            {
                Program.printHeader();
                Console.WriteLine("----- [CITY LIST] -----");
                Console.WriteLine("[1] Search on (State) Name");
                Console.WriteLine("[2] Search on (State) ID");
                Console.WriteLine("[3] Go back");
                Console.Write("Selection: ");
                String selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Program.printHeader();
                        Console.WriteLine("----- [CITY LIST] -----");
                        Console.Write("Search on (State) Name: ");
                        String NameSearch = Console.ReadLine();

                        int ID = DatabaseManager.getStateID(NameSearch);
                        if (ID != 0)
                        {
                            Dictionary<int, String> cities = DatabaseManager.getCityList(ID);

                            Program.printHeader();
                            Console.WriteLine("----- [CITY LIST] -----");
                            Console.WriteLine(DatabaseManager.getStateName(ID) + ":");
                            foreach (int key in cities.Keys)
                                Console.WriteLine($"[ID: {key}] {cities[key]}");

                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No provincie found with that name, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Program.printHeader();
                        Console.WriteLine("----- [CITY LIST] -----");
                        Console.Write("Search on (State) ID: ");
                        int IdSearch = int.Parse(Console.ReadLine());

                        String name2 = DatabaseManager.getStateName(IdSearch);

                        if (name2 != "NULL")
                        {
                            Dictionary<int, String> cities = DatabaseManager.getCityList(IdSearch);

                            Program.printHeader();
                            Console.WriteLine("----- [CITY LIST] -----");
                            Console.WriteLine(name2 + ":");
                            foreach (int key in cities.Keys)
                                Console.WriteLine($"[ID: {key}] {cities[key]}");

                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No provincie found with that ID, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        runLoop = false;
                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void case4()
        {
            Boolean runLoop = true;
            while (runLoop)
            {
                Program.printHeader();
                Console.WriteLine("----- [CITY INFO] -----");
                Console.WriteLine("[1] Search on Name");
                Console.WriteLine("[2] Search on ID");
                Console.WriteLine("[3] Go back");
                Console.Write("Selection: ");
                String selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Program.printHeader();
                        Console.WriteLine("----- [CITY INFO] -----");
                        Console.Write("Search on Name: ");
                        String NameSearch = Console.ReadLine();

                        int ID = DatabaseManager.getCityID(NameSearch);
                        if (ID != 0)
                        {
                            Program.printHeader();
                            Console.WriteLine("----- [CITY INFO] -----");
                            Console.WriteLine("ID: " + ID);
                            Console.WriteLine("Name: " + DatabaseManager.getCityName(ID));
                            Console.WriteLine("Streets: " + DatabaseManager.getStreetCount(ID));
                            Console.WriteLine("State: " + "");
                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No city found with that name, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Program.printHeader();
                        Console.WriteLine("----- [CITY INFO] -----");
                        Console.Write("Search on ID: ");
                        int IdSearch = int.Parse(Console.ReadLine());
                        String name = DatabaseManager.getCityName(IdSearch);

                        if (name != "NULL")
                        {
                            Program.printHeader();
                            Console.WriteLine("----- [CITY INFO] -----");
                            Console.WriteLine("ID: " + IdSearch);
                            Console.WriteLine("Name: " + name);
                            Console.WriteLine("Streets: " + DatabaseManager.getStreetCount(IdSearch));
                            Console.WriteLine("State: " + "");
                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No city found with that ID, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        runLoop = false;
                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void case5()
        {
            Boolean runLoop = true;
            while (runLoop)
            {
                Program.printHeader();
                Console.WriteLine("----- [STREET LIST] -----");
                Console.WriteLine("[1] Search on (City) Name");
                Console.WriteLine("[2] Search on (City) ID");
                Console.WriteLine("[3] Go back");
                Console.Write("Selection: ");
                String selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Program.printHeader();
                        Console.WriteLine("----- [STREET LIST] -----");
                        Console.Write("Search on (City) Name: ");
                        String NameSearch = Console.ReadLine();

                        int ID = DatabaseManager.getCityID(NameSearch);
                        if (ID != 0)
                        {
                            Dictionary<int, String> streets = DatabaseManager.getStreetList(ID);

                            Program.printHeader();
                            Console.WriteLine("----- [STREET LIST] -----");
                            Console.WriteLine(DatabaseManager.getCityName(ID) + ":");
                            foreach (int key in streets.Keys)
                                Console.WriteLine($"[ID: {key}] {streets[key]}");

                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No city found with that name, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Program.printHeader();
                        Console.WriteLine("----- [STREET LIST] -----");
                        Console.Write("Search on (City) ID: ");
                        int IdSearch = int.Parse(Console.ReadLine());
                        String name = DatabaseManager.getCityName(IdSearch);

                        if (name != "NULL")
                        {
                            Dictionary<int, String> streets = DatabaseManager.getStreetList(IdSearch);

                            Program.printHeader();
                            Console.WriteLine("----- [STREET LIST] -----");
                            Console.WriteLine(name + ":");
                            foreach (int key in streets.Keys)
                                Console.WriteLine($"[ID: {key}] {streets[key]}");

                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("No city found with that ID, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        runLoop = false;
                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void case6()
        {
            Boolean runLoop = true;
            while (runLoop)
            {
                Program.printHeader();
                Console.WriteLine("----- [STREET INFO] -----");
                Console.WriteLine("[1] Search on Name");
                Console.WriteLine("[2] Search on ID");
                Console.WriteLine("[3] Go back");
                Console.Write("Selection: ");
                String selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Program.printHeader();
                        Console.WriteLine("----- [STREET INFO] -----");
                        Console.Write("Search on Name: ");
                        String NameSearch = Console.ReadLine();

                        Program.printHeader();
                        Console.WriteLine("----- [STREET INFO] -----");
                        Console.Write("Searching for streets....");

                        Dictionary<int, string> cities = DatabaseManager.getStreetCityList(NameSearch);

                        if (cities.Count > 1)
                        {
                            Console.WriteLine("----- [STREET INFO] -----");
                            Console.Write("Found " + cities.Count + " steets with that name");

                            foreach (int key in cities.Keys)
                                Console.WriteLine($"[ID: {key}] {cities[key]}");

                            Console.WriteLine(" ");
                            Console.Write("City (Name/ID): ");
                            String CitySearch = Console.ReadLine();

                            if (int.TryParse(CitySearch, out int cityID))
                            {
                                if (cities.ContainsKey(cityID))
                                {
                                    int StreetID = DatabaseManager.getStreetID(NameSearch, cityID);
                                    Program.printHeader();
                                    Console.WriteLine("----- [STREET INFO] -----");
                                    Console.WriteLine("ID: " + StreetID);
                                    Console.WriteLine("Name: " + DatabaseManager.getStreetName(StreetID));
                                    Console.WriteLine("Length: " + DatabaseManager.getStreetLength(StreetID)  + "m");
                                    Console.WriteLine("Gemeente: " + cities[cityID]);
                                    subCase6(StreetID);
                                    Console.WriteLine("");
                                    Console.Write("Press ENTER to continue...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Program.printHeader();
                                    Console.WriteLine("----- [STREET INFO] -----");
                                    Console.WriteLine(" ");
                                    Console.Write("No city found with that ID, press ENTER to continue...");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                if (cities.ContainsValue(CitySearch))
                                {
                                    int cityID2 = cities.FirstOrDefault(x => x.Value.ToLower() == CitySearch.ToLower()).Key;

                                    int StreetID = DatabaseManager.getStreetID(NameSearch, cityID2);
                                    Program.printHeader();
                                    Console.WriteLine("----- [STREET INFO] -----");
                                    Console.WriteLine("ID: " + StreetID);
                                    Console.WriteLine("Name: " + DatabaseManager.getStreetName(StreetID));
                                    Console.WriteLine("Length: " + DatabaseManager.getStreetLength(StreetID) + "m");
                                    Console.WriteLine("Gemeente: " + cities[cityID2]);
                                    subCase6(StreetID);
                                    Console.WriteLine("");
                                    Console.Write("Press ENTER to continue...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Program.printHeader();
                                    Console.WriteLine("----- [STREET INFO] -----");
                                    Console.WriteLine(" ");
                                    Console.Write("No city found with that name, press ENTER to continue...");
                                    Console.ReadLine();
                                }
                            }
                        }
                        else if (cities.Count == 1)
                        {
                            int cityID = cities.First().Key;
                            int StreetID = DatabaseManager.getStreetID(NameSearch, cityID);
                            Program.printHeader();
                            Console.WriteLine("----- [STREET INFO] -----");
                            Console.WriteLine("ID: " + StreetID);
                            Console.WriteLine("Name: " + DatabaseManager.getStreetName(StreetID));
                            Console.WriteLine("Length: " + DatabaseManager.getStreetLength(StreetID) + "m");
                            Console.WriteLine("Gemeente: " + cities[cityID]);
                            subCase6(StreetID);
                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Program.printHeader();
                            Console.WriteLine("----- [STREET INFO] -----");
                            Console.WriteLine(" ");
                            Console.Write("No street found with that name, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Program.printHeader();
                        Console.WriteLine("----- [STREET INFO] -----");
                        Console.Write("Search on ID: ");
                        int IdSearch = int.Parse(Console.ReadLine());
                        String name = DatabaseManager.getStreetName(IdSearch);

                        if (name != "NULL")
                        {
                            Program.printHeader();
                            Console.WriteLine("----- [STREET INFO] -----");
                            Console.WriteLine("ID: " + IdSearch);
                            Console.WriteLine("Name: " + name);
                            Console.WriteLine("Length: " + DatabaseManager.getStreetLength(IdSearch) + "m");
                            Console.WriteLine("Gemeente: " + DatabaseManager.getCityName(DatabaseManager.getStreetCityID(IdSearch)));
                            subCase6(IdSearch);
                            Console.WriteLine("");
                            Console.Write("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Program.printHeader();
                            Console.WriteLine("----- [STREET INFO] -----");
                            Console.WriteLine(" ");
                            Console.Write("No street found with that ID, press ENTER to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        runLoop = false;
                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void subCase6(int street)
        {
            Boolean overviewLoop = true;
            while (overviewLoop)
            {
                Console.Write("Do you want to print the street MAP (Y/N)? ");
                String continueExport = Console.ReadLine();

                switch (continueExport.ToUpper())
                {
                    case "Y":
                        Console.CursorTop = 10
;                       String mapString = DatabaseManager.getStreetMapString(street);
                        // Console.WriteLine(mapString);
                        DataManager.printMap(DataManager.buildGraaf(mapString).Map);
                        overviewLoop = false;
                        break;
                    case "N":
                        overviewLoop = false;
                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
