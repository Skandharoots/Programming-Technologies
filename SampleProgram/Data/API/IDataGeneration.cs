using Data.Implementation;
using Data.API;

namespace Data.API {

    public abstract class IDataGeneration {

       public abstract void Fill(IDataRepository dataRepo);
    }
}