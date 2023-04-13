namespace RecordStore
{

    public class RecordStatus
    {
        private Record _record;

        private DateTime _dateOfPurchase;
        public Record Record
        {
            get { return _record;}
            set { _record = value; }
        }

        public DateTime DateOfPurchase
        {
            get { return _dateOfPurchase; }
            set { _dateOfPurchase = value; }
        }

        public RecordStatus(Record record, DateTime dateOfPurchase)
        {
            _record = record;
            _dateOfPurchase = dateOfPurchase;
        }

    }
}