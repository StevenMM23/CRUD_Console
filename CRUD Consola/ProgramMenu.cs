using System;

namespace CRUD_Consola
{
    public abstract class ProgramMenu
    {
        public static void WaitClear()
        {
            Console.ReadLine();
            Console.Clear();
        }
        public static void Menu()
        {
            string answser;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Show Data");
                Console.WriteLine("2 - Insert Data");
                Console.WriteLine("3 - Obtain Data by ID\n");

                Console.Write("Answer: ");
                answser = Console.ReadLine();

                Options(answser);

            }
        }

        public static void Options(string x)
        {
            switch (x)
            {
                case "1":
                    Console.Clear();
                    Show();
                    WaitClear();
                    break;
                case "2":
                    Console.Clear();
                    Insert();
                    WaitClear();
                    break;
                case "3":
                    Console.Clear();
                    int id;
                    Console.WriteLine("Introduce the ID to start the search");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Obtain(id);
                    WaitClear();
                    break;
            }
        }
        public static void Show()
        {
            PeopleDB people = new PeopleDB();
            var x = people.GetAllPeople();

            foreach (var person in x)
            {
                Console.WriteLine($"{person.ID} | {person.Name} | {person.Age}");
            }
        }

        public static void Insert()
        {
            string name;
            int age;
            PeopleDB x = new PeopleDB();

            Console.WriteLine("Introduce el nombre:");
            name = Console.ReadLine();
            Console.WriteLine("Introduce la edad");
            age = Convert.ToInt32(Console.ReadLine());
            x.Insert(name, age);

            Console.Clear();
            Show();
        }

        public static void Obtain(int id)
        {
            PeopleDB x = new PeopleDB();
            x.Obtain(id);
        }
    }
}