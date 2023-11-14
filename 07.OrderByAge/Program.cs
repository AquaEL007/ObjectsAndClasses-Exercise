using System.Xml.Linq;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();

            List<Person> persons = new List<Person>();

            while (input != "End")
            {
                string[] inputArray = input
                .Split();
                string name = inputArray[0];
                string id = inputArray[1];
                int age = int.Parse(inputArray[2]);

                foreach (var item in persons)
                {
                    if (id == item.Id)
                    {
                        item.Name = name;
                        item.Age = age;
                        break;
                    }
                }

                Person person = new Person(inputArray[0], inputArray[1], (int.Parse(inputArray[2])));

                persons.Add(person);    

                input = Console.ReadLine();
            }
            persons = persons.OrderBy(student => student.Age).ToList();

            Console.WriteLine(string.Join("\n", persons));

        }

        class Person
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public int Age { get; set; }

            public Person(string name, string id, int age)
            {
                Name = name;
                Id = id;
                Age = age;
            }
            public override string ToString()
            {
                return $"{Name} with ID: {Id} is {Age} years old.";
            }
        }
    }
}