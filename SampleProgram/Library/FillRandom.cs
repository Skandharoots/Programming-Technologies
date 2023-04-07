using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecordStore;

namespace Fill {

    internal class FillRandom : RecordStore.IDataGeneration {
        static int CLIENT_NUM = 30;
        static int RECORD_NUM = 10;

        static string[] first_names = new string[] {
            "John", "Cristopher", "Walter", "Nick", "Mark",
            "Melanie", "Sophia", "Mary", "Angie", "Sarah"
        };
        static string[] last_names = new string[] {
            "Brown", "Rodriguez", "Rossmann", "Martinez", "Moore",
            "White", "Smith", "Johnson", "Williams", "Jones"
        };

        static string[] record_first = new string[] {
            "White", "Rock n'", "Highway to", "Forgotten", "Lost in", "New"
        };
        static string[] record_second = new string[] {
            "Light", "Roll", "Soul", "Space", "Now", "Fire"
        };


        public void Fill(DataContext dataContext) {

            Random random = new Random();

            for (int i = 0; i < CLIENT_NUM; i++)
                dataContext.clients.Add(new Client(
                    first_names[random.Next(10)],
                    last_names[random.Next(10)]
                    ));

            for (int i = 0; i < RECORD_NUM; i++)
                dataContext.records.Add(i, new Record(
                    first_names[random.Next(10)] + " " + last_names[random.Next(10)],
                    record_first[random.Next(6)] + " " + record_second[random.Next(6)]
                    ));

            

        }
    }
}
