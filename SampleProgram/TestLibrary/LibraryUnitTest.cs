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
        Assert.AreEqual("Nevermind", actual);
        RecordStatus rstatus = new RecordStatus(record, DateTime.Today);
        DateTime actualTime = DateTime.Today;
        Assert.AreEqual(actualTime, rstatus.DateOfPurchase);
    }
}