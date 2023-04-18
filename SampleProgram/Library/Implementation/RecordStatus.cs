using Data.API;

namespace Data.Implementation
{

    public class RecordStatus : IRecordStatus
    {
        private IRecord Record;

        public DateTime DateOfPurchase { get; set; }
       
        public RecordStatus(IRecord record, DateTime dateOfPurchase)
        {
            Record = record;
            DateOfPurchase = dateOfPurchase;
        }

    }
}