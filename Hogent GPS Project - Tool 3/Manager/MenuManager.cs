using System;
using System.Collections.Generic;
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
                            int count = DatabaseManager.getGemeenteCount(ID);
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
                            int count = DatabaseManager.getGemeenteCount(IdSearch);
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

                        Gemeente gemeente = Program.Cities.Single(x => x.Value.Name.ToLower() == NameSearch.ToLower()).Value;
                        if (gemeente != null)
                        {
                            Program.printHeader();
                            Console.WriteLine("----- [CITY INFO] -----");
                            Console.WriteLine("ID: " + gemeente.ID);
                            Console.WriteLine("Name: " + gemeente.Name);
                            Console.WriteLine("Streets: " + gemeente.straten.Count);
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
                        String IdSearch = Console.ReadLine();
                        if (Program.Cities.ContainsKey(int.Parse(IdSearch)))
                        {
                            Gemeente gemeente2 = Program.Cities[int.Parse(IdSearch)];
                            Program.printHeader();
                            Console.WriteLine("----- [PROVINCIE STATS] -----");
                            Console.WriteLine("ID: " + gemeente2.ID);
                            Console.WriteLine("Name: " + gemeente2.Name);
                            Console.WriteLine("Streets: " + gemeente2.straten.Count);
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
    }
}
