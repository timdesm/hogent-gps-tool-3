using System;

namespace Hogent_GPS_Project___Tool_3
{
    class Program
    {
        public static String appData;

        public static DatabaseUtil db;
        public static String mysql_host = "timdesmet.be";
        public static String mysql_user = "u32002p26917_hogent";
        public static String mysql_pass;
        public static String mysql_data = "u32002p26917_hogent";

        static void Main(string[] args)
        {
            Boolean isConnected = false;
            while(!isConnected)
            {
                printHeader();
                Console.Write("Database password?: ");
                mysql_pass = Console.ReadLine();
                db = new DatabaseUtil(mysql_host, mysql_user, mysql_pass, mysql_data);

                int status = db.checkConnection();
                switch(status)
                {
                    case 1:
                        isConnected = true;
                        break;
                    case 1042:
                        Console.WriteLine("Unabale to create connection!");
                        Console.WriteLine(" ");
                        Console.Write("Press ENTER to continue...");
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Invalid password!");
                        Console.WriteLine(" ");
                        Console.Write("Press ENTER to continue...");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }

            while (true)
            {
                printHeader();
                Console.WriteLine("Database connected");
                Console.WriteLine(" ");

                Console.WriteLine("----- [MENU] -----");
                Console.WriteLine("[1] PROVINCIE LIST");
                Console.WriteLine("[2] PROVINCIE INFO");
                Console.WriteLine("[3] CITY LIST");
                Console.WriteLine("[4] CITY INFO");
                Console.WriteLine("[5] STREET LIST");
                Console.WriteLine("[6] STREET INFO");
                Console.WriteLine("[7] DATABASE STATUS");
                Console.Write("Selection: ");
                String selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        MenuManager.case1();
                        break;
                    case "2":
                        MenuManager.case2();
                        break;
                    case "3":
                        MenuManager.case3();
                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    default:
                        Console.Write("Wrong selection input, press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Project created by Tim De Smet");
            Console.WriteLine("HoGent GPS - Tool 3");
            Console.WriteLine("--------------------------");
            Console.WriteLine(" ");
        }
    }
}
