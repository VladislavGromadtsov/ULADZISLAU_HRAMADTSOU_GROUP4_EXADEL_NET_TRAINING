using System;
using System.Text;
using System.Linq;
using System.Text.Json;

namespace Task3_2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string citiesInputPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\InputFiles\\city.json";
            string inhabitantsInputPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\InputFiles\\inhabitant.json";

            List<Cities?>? city;
            List<Inhabitants?>? inhabitant;

            Console.WriteLine("Input:");
            (city, inhabitant) = ReadInputFiles(citiesInputPath, inhabitantsInputPath);

            if (city is not null && inhabitant is not null)
            {
                var selectedPeople = from person in inhabitant
                                     from town in city
                                     where person.City == town.City && town.Population >= 50000
                                     select person;

                Console.WriteLine("Output:");
                PrintResultInhabitants(selectedPeople);
            }
            
        }

        private static (List<Cities?>?, List<Inhabitants?>?) ReadInputFiles (string citiesPath, string inhabitantsPath)
        {
            List<Cities?>? cities;
            List<Inhabitants?>? inhabitants;
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            using (FileStream fileStream = File.OpenRead(citiesPath))
            {
                cities = JsonSerializer.Deserialize<List<Cities?>>(fileStream, options);
            }

            using (FileStream fileStream = File.OpenRead(inhabitantsPath))
            {
                inhabitants = JsonSerializer.Deserialize<List<Inhabitants?>>(fileStream, options);
            }

            Console.WriteLine(Path.GetFileName(citiesPath));
            using (StreamReader reader = new StreamReader(citiesPath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            Console.WriteLine(Path.GetFileName(inhabitantsPath));
            using (StreamReader reader = new StreamReader(inhabitantsPath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            return (cities, inhabitants);
        }

        private static void PrintResultInhabitants(IEnumerable<Inhabitants> selectedPeople)
        {
            foreach (var item in selectedPeople)
            {
                if (item.Age >= 0 && item.Age <= 15 || item.Age >= 65 && item.Age <= 100)
                {
                    Console.WriteLine($"{item.Name} {item.Surname} is not employed");
                }
                else if (item.Age > 15 && item.Age < 65)
                {
                    Console.WriteLine($"{item.Name} {item.Surname} is employed");
                }
            }
        }
    }
}