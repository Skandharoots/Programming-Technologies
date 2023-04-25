using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Data.Implementation;
using Logic.Implementation;

namespace TestLibrary
{
    internal class FillConstantValues : IDataGeneration
    {
        public override void Fill(IDataRepository dataRepo)
        {
            dataRepo.AddClient(new Client("Marek", "Kopania"));
            dataRepo.AddClient(new Client("Mateusz", "Kubiak"));
            dataRepo.AddClient(new Client("Grzegoz", "Brzeczyszczykiewicz"));
            dataRepo.AddClient(new Client("Patryk", "Wazny"));
            dataRepo.AddClient(new Client("Karol", "Bukowski"));

            dataRepo.AddRecord(new Record(0, "Nirvana", "Nevermind"));
            dataRepo.AddRecord(new Record(1, "Nirvan", "Nevermin"));
            dataRepo.AddRecord(new Record(2, "Nirva", "Nevermi"));
            dataRepo.AddRecord(new Record(3, "Nirv", "Neverm"));
            dataRepo.AddRecord(new Record(4, "Nir", "Never"));

            dataRepo.AddRecordStatus(new RecordStatus(dataRepo.GetRecord(0), DateTime.Now));
            dataRepo.AddRecordStatus(new RecordStatus(dataRepo.GetRecord(1), DateTime.Now));
            dataRepo.AddRecordStatus(new RecordStatus(dataRepo.GetRecord(2), DateTime.Now));

            dataRepo.AddEvent(new Event(dataRepo.GetClient(0), dataRepo.GetRecordStatus(0), DateTime.Now, DateTime.Now.AddHours(3)));
            dataRepo.AddEvent(new Event(dataRepo.GetClient(3), dataRepo.GetRecordStatus(1), DateTime.Now, DateTime.Now.AddHours(3)));
            dataRepo.AddEvent(new Event(dataRepo.GetClient(2), dataRepo.GetRecordStatus(2), DateTime.Now, DateTime.Now.AddHours(3)));

        }
    }
}
