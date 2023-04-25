using Data.API;

namespace Data.Implementation {

    internal class RecordStatus : IRecordStatus {

        public IRecord record { get; set; }
        public bool available { get; set; }
        public DateTime DateOfPurchase { get; set; }
        
        public RecordStatus(bool available, IRecord record, DateTime dateOfPurchase) {
            this.record = record;
            this.available = available;
            DateOfPurchase = dateOfPurchase;
        }
    }
}