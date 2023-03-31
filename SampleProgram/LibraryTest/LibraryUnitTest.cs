using RecordStore;

namespace TestLibrary;

public class Tests
{
    /* [SetUp]
     public void Setup()
     {
     }
 */
    [Test]
    public void Test1()
    {
        Record record = new Record("Nevermind", "Kurt Cobain");
        string actual = record.Title;
        Console.WriteLine(record.ToString());
        Assert.AreEqual("Nevermind", actual);
        RecordStatus rstatus = new RecordStatus(record, DateTime.Today);
        DateTime actualTime = DateTime.Today;
        Assert.AreEqual(actualTime, rstatus.DateOfPurchase);
        DateTime rentalDate = new DateTime(2022, 05, 23);
        Event eventOne = new Event(record, new Client("Marek", "Kopania"), rentalDate, DateTime.Now);
        Console.WriteLine(eventOne.ToString());
    }
}