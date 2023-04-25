using Data.API;

namespace Data.Implementation {

    internal class Rent : IEvent {

        public IClient client { get; set; }

        public IRecordStatus status { get; set; }  
        public DateTime PurchaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
        //IClient IEvent.client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //IRecordStatus IEvent.status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Rent(IClient client, IRecordStatus status, DateTime rentalDate, DateTime returnDate = default) {
            this.client = client;
            this.status = status;
            PurchaseDate = rentalDate;
            ReturnDate = returnDate;
        }
    }
}