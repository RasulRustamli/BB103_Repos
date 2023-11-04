namespace bb103_enums
{
    internal class Course
    {
        public string Name { get; set; }
        Person[] Persons;
        public Person this[int index]
        {
            get
            {
                return Persons[index];
            }
            set
            {
                if (index > Persons.Length - 1)
                {
                    Console.WriteLine($"{index} Bele bir index yoxdur maxsimum index {Length - 1}-dir ");
                }
                else
                {

                    Persons[index] = value;
                }
            }
        }

        public int Length
        {
            get
            {
                return Persons.Length;
            }
        }
        public Course()
        {
            Persons = new Person[0];
        }

        public void AddPerson(Person person)
        {
            Array.Resize(ref Persons, Length + 1);
            Persons[^1] = person;
        }
        public void AddPerson(params Person[] person)
        {
            for (int i = 0; i < person.Length; i++)
            {
                AddPerson(person[i]);
            }
        }

        public Person[] PoistionFilter(string position)
        {
            Person[] filtiredPersons = new Person[0];

            for (int i = 0; i <Length; i++)
            {
                if (Persons[i].Position.ToString().ToLower() == position.ToLower())
                {
                    Array.Resize(ref filtiredPersons, filtiredPersons.Length + 1);
                    filtiredPersons[^1] = Persons[i];
                }
            }
            return filtiredPersons;
        }
        public Person[] PoistionFilter(int value)
        {
            Person[] filtiredPersons = new Person[0];

            for (int i = 0; i < Length; i++)
            {
                if ((int)Persons[i].Position == value)
                {
                    Array.Resize(ref filtiredPersons, filtiredPersons.Length + 1);
                    filtiredPersons[^1] = Persons[i];
                }
            }
            return filtiredPersons;
        }

    }
}
