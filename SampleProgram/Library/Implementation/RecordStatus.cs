using Data.API;

namespace Data.Implementation
{

    internal class RecordStatus : IRecordStatus
    {
        private IRecord Record;

        public DateTime DateOfPurchase { get; set; }
        IRecord IRecordStatus.Record { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RecordStatus(IRecord record, DateTime dateOfPurchase)
        {
            Record = record;
            DateOfPurchase = dateOfPurchase;
        }

    }
}