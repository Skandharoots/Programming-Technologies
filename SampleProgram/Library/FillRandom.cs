﻿

namespace RecordStore {

    internal class FillRandom : IDataGeneration {
        static int CLIENT_NUM = 30;
        static int RECORD_NUM = 10;
        static int EVENT_NUM = 30;

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

        public void Fill(DataContext dataContext) {
            FillClients(dataContext);
            FillRecords(dataContext);
            FillEvents(dataContext);
            FillRecordStatuses(dataContext);
        }

        private void FillClients(DataContext dataContext) {
            Random random = new Random();
            for (int i = 0; i < CLIENT_NUM; i++)
                dataContext.clients.Add(new Client(
                    first_names[random.Next(10)],
                    last_names[random.Next(10)]
                ));
        }

        private void FillRecords(DataContext dataContext) {
            Random random = new Random();
            for (int i = 0; i < RECORD_NUM; i++)
                dataContext.records.Add(i, new Record(
                    first_names[random.Next(10)] + " " + last_names[random.Next(10)],
                    record_first[random.Next(6)] + " " + record_second[random.Next(6)]
                ));
        }

        private void FillEvents(DataContext dataContext) {
            Random random = new Random();
            for (int i = 0; i < EVENT_NUM; i++)
                dataContext.events.Add(new Event(
                    dataContext.records[random.Next(dataContext.records.Count)],
                    dataContext.clients[random.Next(dataContext.clients.Count)],
                    generateRandomDate(),
                    generateRandomDate()
                ));
        }

        private void FillRecordStatuses(DataContext dataContext) {
            Random random = new Random();
            for (int i = 0; i < RECORD_NUM; i++)
                dataContext.recordStatuses.Add(new RecordStatus(
                    dataContext.records[random.Next(dataContext.records.Count)],
                    generateRandomDate()
                ));
        }

        private DateTime generateRandomDate() {
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
