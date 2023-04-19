using Data.API;
using Data.Implementation;

namespace Data.Implementation
{

    internal class FillConstant : IDataGeneration
    {

        static string[] first_names = new string[] {
            "Emily", "David", "Madison", "Christopher", "Samantha",
            "Matthew", "Ashley", "Tyler", "Elizabeth", "Jonathan",
            "Lauren", "Michael", "Olivia", "Nicholas", "Sarah",
            "Andrew", "Hannah", "William", "Victoria", "Benjamin"
        };
        static string[] last_names = new string[] {
            "Johnson", "Smith", "Williams", "Brown", "Davis",
            "Wilson", "Martinez", "Thompson", "Garcia", "Robinson",
            "Hernandez", "Miller", "Lee", "Jackson", "White",
            "Perez", "Taylor", "Anderson", "Wright", "King"
        };

        static string[] record_authors = new string[] {
            "Sophia Martinez", "Gabriel Davis", "Ava Cooper", "Ethan Thompson", "Isabella Garcia",
            "Isaac Wright", "Mia Hernandez", "Alexander King", "Charlotte Brown", "Daniel Wilson",
            "Emma Johnson", "Nathan Lee", "Abigail Robinson", "Jacob Smith", "Lily Anderson",
            "Lucas White", "Chloe Jackson", "Caleb Williams", "Harper Miller", "Owen Taylor"
        };
        static string[] record_names = new string[] {
            "Dreamland Odyssey", "Electric Jungle", "Crystal Skies", "Sunset Boulevard", "Midnight Mirage",
            "Neon Nightscape", "Wildfire Symphony", "Starlight Serenade", "Cosmic Collision", "Oceanic Rhapsody",
            "Galactic Groove", "Thunderous Echoes", "Frosty Solitude", "Tropical Tango", "Mystical Mountains",
            "Rainbow Reverie", "Enchanted Oasis", "Solar Eclipse", "Funky Fusion", "Aurora Borealis"
        };

        static string[] dates_rented = {
            "07-Apr-2023 08:30:00 AM", "15-May-2023 02:00:00 PM",
            "22-Jun-2023 07:30:00 PM", "04-Jul-2023 12:00:00 PM",
            "10-Aug-2023 09:30:00 AM", "17-Sep-2023 04:00:00 PM",
            "25-Oct-2023 09:30:00 PM", "11-Nov-2023 10:00:00 AM",
            "20-Dec-2023 03:30:00 PM", "05-Jan-2024 06:00:00 PM",
            "14-Feb-2024 07:30:00 AM", "22-Mar-2024 01:00:00 PM",
            "29-Apr-2024 08:30:00 PM", "07-May-2024 11:00:00 AM",
            "15-Jun-2024 05:30:00 PM", "22-Jul-2024 10:00:00 PM",
            "30-Aug-2024 09:30:00 AM", "06-Sep-2024 02:00:00 PM",
            "14-Oct-2024 07:30:00 PM", "21-Nov-2024 12:00:00 PM"
        };

        static string[] dates_returned = {
            "14-Apr-2023 08:30:00 AM", "22-May-2023 02:00:00 PM",
            "29-Jun-2023 07:30:00 PM", "11-Jul-2023 12:00:00 PM",
            "17-Aug-2023 09:30:00 AM", "24-Sep-2023 04:00:00 PM",
            "02-Nov-2023 09:30:00 PM", "18-Nov-2023 10:00:00 AM",
            "27-Dec-2023 03:30:00 PM", "12-Jan-2024 06:00:00 PM",
            "21-Feb-2024 07:30:00 AM", "28-Mar-2024 01:00:00 PM",
            "05-May-2024 08:30:00 PM", "13-Jun-2024 11:00:00 AM",
            "21-Jul-2024 05:30:00 PM", "28-Aug-2024 10:00:00 PM",
            "05-Oct-2024 09:30:00 AM", "12-Oct-2024 02:00:00 PM",
            "20-Nov-2024 07:30:00 PM", "27-Dec-2024 12:00:00 PM"
        };

        static string[] dates_created = {
            "06-Feb-2010 02:45:00 PM", "20-Aug-2010 10:30:00 AM",
            "18-Sep-2010 08:15:00 PM", "03-Nov-2010 05:45:00 AM",
            "22-Jan-2011 11:00:00 AM", "02-May-2011 04:30:00 PM",
            "17-Jul-2011 09:15:00 PM", "12-Sep-2011 01:00:00 PM",
            "29-Oct-2011 06:30:00 AM", "08-Feb-2012 03:45:00 PM",
            "24-Apr-2012 10:30:00 AM", "30-Jun-2012 08:15:00 PM",
            "11-Aug-2012 05:45:00 AM", "01-Oct-2012 11:00:00 AM",
            "17-Dec-2012 04:30:00 PM", "20-Jan-2010 01:15:00 PM",
            "07-Apr-2010 08:45:00 PM", "25-Jun-2010 11:00:00 AM",
            "14-Aug-2010 05:30:00 PM", "22-Dec-2010 10:00:00 PM"
        };

        public FillConstant()
        {

        }

        public void Fill(IDataRepository dataRepo)
        {
            FillClients(dataRepo);
            FillRecords(dataRepo);
            FillEvents(dataRepo);
            FillRecordStatuses(dataRepo);
        }

        public void FillClients(IDataRepository dataRepo)
        {
            Random random = new Random();
            for (int i = 0; i < first_names.Count(); i++)
                dataRepo.AddClient(new Client(
                    first_names[i],
                    last_names[i]
                ));
        }

        public void FillRecords(IDataRepository dataRepo)
        {
            for (int i = 0; i < record_names.Count(); i++)
                dataRepo.AddRecord(new Record(i,
                    record_authors[i],
                    record_names[i]
                ));
        }

        public void FillEvents(IDataRepository dataRepo)
        {
            for (int i = 0; i < record_names.Count(); i++)
                dataRepo.AddEvent(new Event(
                    i,
                    DateTime.Parse(dates_rented[i]),
                    DateTime.Parse(dates_returned[i])
                ));
        }

        public void FillRecordStatuses(IDataRepository dataRepo)
        {
            for (int i = 0; i < record_names.Count(); i++)
                dataRepo.AddRecordStatus(new RecordStatus(
                    dataRepo.GetRecord(i),
                    DateTime.Parse(dates_created[i])
                ));
        }

    }
}
