using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Data.Implementation;


namespace TestLibrary
{
    internal class FillRandomValues : IDataGeneration
    {

        public override void Fill(IDataRepository dataRepo)
        {
            FillClients(dataRepo);
            FillRecords(dataRepo);
            FillRecordStatuses(dataRepo);
            FillEvents(dataRepo);
        }

        static string[] first_names = new string[] {
            "John", "Cristopher", "Walter", "Nick", "Mark",
            "Melanie", "Sophia", "Mary", "Angie", "Sarah"
        };

        static string[] last_names = new string[] {
            "Brown", "Rodriguez", "Rossmann", "Martinez", "Moore",
            "White", "Smith", "Johnson", "Williams", "Jones"
        };

        static string[] record_first = new string[] {
            "White", "Rock n'", "Highway to", "Forgotten", "Lost in", "New"
        };

        static string[] record_second = new string[] {
            "Light", "Roll", "Soul", "Space", "Now", "Fire"
        };


        public void FillClients(IDataRepository dataRepo)
        {
            Random random = new Random();
            for (int i = 0; i < 30; i++)
                dataRepo.AddClient(new Client(
                    first_names[random.Next(10)],
                    last_names[random.Next(10)]
                ));
        }

        public void FillRecords(IDataRepository dataRepo)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
                dataRepo.AddRecord(new Record(i,
                    first_names[random.Next(10)] + " " + last_names[random.Next(10)],
                    record_first[random.Next(6)] + " " + record_second[random.Next(6)]
                ));
        }

        public void FillEvents(IDataRepository dataRepo)
        {
            Random random = new Random();
            for (int i = 0; i < 30; i++)
                dataRepo.AddEvent(new Rent(
                    dataRepo.GetClient(random.Next(20)),
                    dataRepo.GetRecordStatus(random.Next(10)),
                    generateRandomDate(),
                    generateRandomDate()
                ));
        }

        public void FillRecordStatuses(IDataRepository dataRepo)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
                dataRepo.AddRecordStatus(new RecordStatus(
                    true,
                    dataRepo.GetRecord(random.Next(10)),
                    generateRandomDate()
                ));
        }

        public DateTime generateRandomDate()
        {
            Random random = new Random();
            DateTime minDate = new DateTime(2000, 1, 1);
            DateTime maxDate = new DateTime(1025, 1, 1);
            int range = (DateTime.Today - minDate).Days;

            TimeSpan randomTimeSpan = new TimeSpan(random.Next(0, 24), random.Next(0, 60), random.Next(0, 60), random.Next(0, 1000 * 1000 * 10));
            DateTime randomDateTime = minDate.AddDays(random.Next(range)).Add(randomTimeSpan);

            return randomDateTime;
        }
    }
}
