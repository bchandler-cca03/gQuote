using System.Collections.Generic;

namespace CktMgr.CircuitLib
{
    public interface ICircuitRepo
    {
        Circuit GetById(int Id);
        List<Circuit> ListAll();
        void AddCircuit(Circuit newCircuit);
        List<Circuit> SearchAddress(SearchModel modelToSearch);
        List<Circuit> SearchAddressPageReturn(SearchModel modelToSearch, int pageNumber);
    }
}