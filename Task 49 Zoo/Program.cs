using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_49_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartGame();
        }
    }

    class Animal
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Sound { get; set; }

        public Animal(string name, string gender, string sound)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}. Пол: {Gender}. Издаваемый звук: {Sound}.");
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public string Name { get; private set; }
       
        public Aviary(Random random ,string nameAviary, string nameAnimals, string sound)
        {
            Name = nameAviary;
            AddAnimals(random ,nameAnimals, sound);
        }

        public void ShowAllAnimals()
        {
            Console.WriteLine($"Вольер: {Name}. Список животных:");

            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].ShowInfo();
            }
        }

        private void AddAnimals(Random random, string name, string sound)
        {
            int minNumberAnimals = 3;
            int maxNumberAnimals = 10;

            for (int i = 0; i < random.Next(minNumberAnimals, maxNumberAnimals); i++)
            {
                _animals.Add(new Animal(name, AssignRandomGender(random), sound));
            }
        }

        private string AssignRandomGender(Random random)
        {
            string firstGender = "Мужской";
            string secondGender = "Женский";
            int minLimit = 0;
            int maxLimit = 100;
            int percentageAssignment = 50;

            if (random.Next(minLimit, maxLimit) <= percentageAssignment)
            {
                return firstGender;
            }
            else
            {
                return secondGender;
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private Random _random = new Random();

        public Zoo()
        {
            AddAviaries();
        }

        public void StartGame()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Ввведите номер вольера, к которому хотите подойти:\n");
                ShowAllAviaries();
                SearchAviaries();
            }
        }

        public void ShowAllAviaries()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i+1}. Вольер: {_aviaries[i].Name}");
            }
        }

        private void SearchAviaries()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int index);

            if (isNumber == true && index - 1 < _aviaries.Count && index > 0)
            {
                ShowSpecificAviary(index);
            }
            else
            {
                Console.WriteLine("Данного вольера нет");
            }
        }

        private void ShowSpecificAviary(int index)
        {
            _aviaries[index - 1].ShowAllAnimals();
        }

        private void AddAviaries()
        {
            _aviaries.Add(new Aviary(_random, "Жирафы", "Жираф", "Громко мычит"));
            _aviaries.Add(new Aviary(_random, "Обезъяны", "Обезъяна", "Издаёт короткие звуки у-у"));
            _aviaries.Add(new Aviary(_random, "Тигры", "Тигр", "Рычит"));
            _aviaries.Add(new Aviary(_random, "Манулы", "Манул", "Громка мяукает"));        }
    }
}
