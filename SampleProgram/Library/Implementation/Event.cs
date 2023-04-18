using Data.API;

namespace Data.Implementation
{

    internal class Event : IEvent
    {

        public int RecordId { get; set; }

        public DateTime PurchaseDate { get; set; }  
        

        public DateTime ReturnDate { get; set; }
        
        public Event(int recordId, DateTime rentalDate, DateTime returnDate = default)
        {
            RecordId = recordId;
            PurchaseDate = rentalDate;
            ReturnDate = returnDate;
        }

    }
}