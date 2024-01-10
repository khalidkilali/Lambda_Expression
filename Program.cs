namespace Lambda_Expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saisir le nom du collaborateur");
            string name = Console.ReadLine();
            var collab = new Collab().GetFirstOrdefault(name);

            if (collab == null)
            {
                Console.WriteLine("Collab Not Found");
            }
            else
            {
                Console.WriteLine($"ID : {collab.ID}, Prenom {collab.FirstName}, nom {collab.LastName}");
            }
        }
    }


    class Collab
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public IQueryable<Collab> getAll()
        {
            var listCollab = new List<Collab>()
            {
                new Collab { ID = 1, FirstName="Khalid", LastName ="Khalid"},
                new Collab { ID = 2, FirstName="Olivier", LastName ="Olivier"},
                new Collab { ID = 3, FirstName="Collab3", LastName ="Collab3"}
            };

            return listCollab.AsQueryable();
        }

        public Collab GetFirstOrdefault(string name)
        {
            var collab = getAll().FirstOrDefault(x => x.FirstName.ToLower() == name.ToLower());

            return collab;
        }
    }
}