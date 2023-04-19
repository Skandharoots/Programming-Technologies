using Data.Implementation;
using Data.API;

namespace Data.API
{

    public interface IDataGeneration
    {

       public abstract void Fill(IDataRepository dataRepo);

    }
}