namespace RecordStore
{

    public class Client
    {

        private string _name;

        private string _surname;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public Client(string firstName, string lastName)
        {
            _name = firstName;
            _surname = lastName;
        }

        public void SetName(string newName = "default", string newSurname = "default")
        {
            if (newName != "default")
            {
                _name = newName;
            }

            if (newSurname != "default")
            {
                _surname = newSurname;
            }
        }

    }
}