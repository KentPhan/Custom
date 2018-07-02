using System;
using System.IO;

namespace CSVGeneratorHelpers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gimme a file path to add crap to");
            string path = Console.ReadLine();


            //if (args.Length != 1)
            //{
            //    Console.WriteLine("Invalid number of parameters. Only accepts one parameter of a path name to import.");
            //    return;
            //}

            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                Console.ReadLine();

                return;
            }

            var helper = new CSVHelpers(path);
            helper.AppendGeneratedColumn("StateCode", GenerateStates);
            //helper.AppendGeneratedColumn("Name", GenerateName);
            //helper.AppendGeneratedColumn("City", GenerateCity);
            //helper.AppendGeneratedColumn("Zip", GenerateZip);
            //helper.AppendGeneratedColumn("City", GenerateCity);

            Console.WriteLine("DONE");
        }


        private static Random rand = new Random();
        private static string[] firstNames = new string[5] { "Bob", "Sally", "Charlie", "May", "Loki" };
        private static string[] middleNames = new string[5] { "D", "Master", "Bomb", "Savage", "Beam" };
        private static string[] lastNames = new string[5] { "Poppins", "Ender", "Death", "Love", "Anderson" };

        private static string[] states = new string[51]
        {
            "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware",
            "District of Columbia", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas",
            "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi",
            "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York",
            "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island",
            "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington",
            "West Virginia", "Wisconsin", "Wyoming"
        };


        public static string GenerateStates(int i)
        {
            return states[rand.Next(0, 50)];
        }
        public static string GenerateName(int i)
        {
            return $"{firstNames[rand.Next(0, 4)]} {middleNames[rand.Next(0, 4)]} {lastNames[rand.Next(0, 4)]}";
        }

        public static string GenerateCity(int i)
        {
            return $"Some City {i}";
        }

        public static string GenerateZip(int i)
        {
            return $"8{i}";
        }


    }
}
