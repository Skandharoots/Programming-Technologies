using Data.API;

namespace Data.Implementation {

    internal class RecordStatus : IRecordStatus {

        public IRecord record { get; set; }
        public int RecordId => record.Id;
        public DateTime DateOfPurchase { get; set; }
        
        public RecordStatus(IRecord record, DateTime dateOfPurchase) {
            this.record = record;
            DateOfPurchase = dateOfPurchase;
        }
    }
}