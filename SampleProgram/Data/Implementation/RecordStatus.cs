using Data.API;

namespace Data.Implementation {

    internal class RecordStatus : IRecordStatus {

        private readonly IRecord record;
        public int RecordId => record.Id;
        public DateTime DateOfPurchase { get; set; }
        
        public RecordStatus(IRecord record, DateTime dateOfPurchase) {
            this.record = record;
            DateOfPurchase = dateOfPurchase;
        }
    }
}