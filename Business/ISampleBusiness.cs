using System.Collections.Generic;

namespace Business
{
    public interface ISampleBusiness
    {
        IEnumerable<string> ListAllData();
        string ListOneData(int id);
    }
}