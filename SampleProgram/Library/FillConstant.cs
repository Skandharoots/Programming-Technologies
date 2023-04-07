

namespace RecordStore {

    public class FillConstant : IDataGeneration {

        private int CLIENT_NUM = 3;
        private int RECORD_NUM = 3;
        private int EVENT_NUM = 3;
        private int STATUS_NUM = 3;

        public FillConstant()
        {

        }

        public void Fill(DataContext dataContext) {
            FillClients(dataContext);
            FillRecords(dataContext);
            FillEvents(dataContext);
            FillRecordStatuses(dataContext);
        }

        public void FillClients(DataContext dataContext) {
            for (int i = 0; i < CLIENT_NUM; i++) {
                Console.WriteLine("[Client no." + i + "]");

                Console.WriteLine("Write first and last name:");
                string[] names = Console.ReadLine().Split(' ');

                dataContext.clients.Add(new Client(
                    names[0],
                    names[1]
                ));
            }
        }

        public void FillRecords(DataContext dataContext) {
            for (int i = 0; i < RECORD_NUM; i++) {
                Console.WriteLine("[Record no." + i + "]");

                Console.WriteLine("Write author:");
                string author = Console.ReadLine();

                Console.WriteLine("Write record name:");
                string record = Console.ReadLine();

                dataContext.records.Add(i, new Record(
                     author,
                     record
                ));
            }
        }

        public void FillEvents(DataContext dataContext) {
            for (int i = 0; i < EVENT_NUM; i++) {
                Console.WriteLine("[Event no." + i + "]");

                Console.WriteLine("Choose Record index: (0-" + (int)(RECORD_NUM - 1) + "):");
                int record_i = int.Parse(Console.ReadLine());

                Console.WriteLine("Choose Client index: (0-" + (int)(CLIENT_NUM - 1) + "):");
                int client_i = int.Parse(Console.ReadLine());

                Console.WriteLine("Write rent DateTime:");
                DateTime rent_date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Write return DateTime:");
                DateTime return_date = DateTime.Parse(Console.ReadLine());

                dataContext.events.Add(new Event(
                        dataContext.records[record_i],
                        dataContext.clients[client_i],
                        rent_date,
                        return_date
                ));
            }
        }

        public void FillRecordStatuses(DataContext dataContext) {
            for (int i = 0; i < STATUS_NUM; i++) {
                Console.WriteLine("[Status no." + i + "]");

                Console.WriteLine("Choose Record index: (0-" + (int)(RECORD_NUM - 1) + "):");
                int record_i = int.Parse(Console.ReadLine());

                Console.WriteLine("Write purchase DateTime:");
                DateTime purchase_date = DateTime.Parse(Console.ReadLine());

                dataContext.recordStatuses.Add(new RecordStatus(
                    dataContext.records[record_i],
                    purchase_date
                ));
            }
        }
    }
}
