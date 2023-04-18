using Data.API;

namespace Data.Implementation
{

    internal class Client : IClient
    {

        public string Name { get; set; }
       
        public string Surname { get; set; }
       

        public Client(string firstName, string lastName)
        {
            Name = firstName;
            Surname = lastName;
        }

    }
}