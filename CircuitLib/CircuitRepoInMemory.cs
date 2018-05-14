using System;
using System.Collections.Generic;
using System.Text;

namespace CktMgr.CircuitLib
{
    public class CircuitRepoInMemory : ICircuitRepo
    {
        private static List<Circuit> _circuits;
        private static int _nextId = 1;  //ZZZ return to minute 43

        public CircuitRepoInMemory()
        {
            if (_circuits == null)
            {
                _circuits = new List<Circuit>();
            }
        }
        public List<Circuit> ListAll()
        {
            // TODO:  Read from database
            return new List<Circuit>();
        }

        public Circuit GetById(int Id)
        {
            // TODO:  Read from database
            return _circuits.Find(ckt => ckt.Id == Id);
        }

        public void AddCircuit(Circuit newCircuit)
        {
            newCircuit.Id = _nextId++;
            _circuits.Add(newCircuit);
        }
        public List<Circuit> SearchAddress(SearchModel searchToComplete)
        {
            throw new NotImplementedException();
        }
        public List<Circuit> SearchAddressPageReturn(SearchModel searchToComplete, int pageNumber)
        {
            throw new NotImplementedException();
        }


    }
}
