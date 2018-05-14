using System;
using System.Collections.Generic;
using System.Text;

namespace CktMgr.CircuitLib
{
    public class CircuitRepo : ICircuitRepo
    {
        private static List<Circuit> _cktList = new List<Circuit>();
        private static int nextId = 0;
      
        public List<Circuit> ListAll()
        {
            return _cktList;
        }

        public Circuit GetById(int Id)
        {
            return _cktList.Find(ckt => ckt.Id == Id);
        }
        // public void Add(Circuit newCkt)
        // {
        //     newCkt.Id = nextId++;
        //     var sNum = (nextId * 67).ToString();
        //     var placeString = sNum + newCkt.Address.ToString();
        //    newCkt.Address = placeString;
        //
        //    _cktList.Add(newCkt);
        // }

        public void AddCircuit(Circuit newCircuit)
        {
            newCircuit.Id = nextId++;
            var sNum = (nextId * 67).ToString();
            var placeString = sNum + newCircuit.Address.ToString();
            newCircuit.Address = placeString;
            _cktList.Add(newCircuit);

        }

        public List<Circuit> SearchAddress(SearchModel searchToComplete)
        {
            throw new NotImplementedException();
        }
        public List<Circuit> SearchAddressPageReturn(SearchModel searchToComplete, int pageNumber)
        {
            throw new NotImplementedException();
        }



        // public void Edit(Circuit editCkt)
        // {
        //    var origCkt = GetById(editCkt.Id);
        //    origCkt.Id = editCkt.Id;
        //    origCkt.AEndStreetNum = editCkt.AEndStreetNum;
        //    origCkt.AEndStreetName = editCkt.AEndStreetName;
        //    origCkt.AEndStreetType = editCkt.AEndStreetType;
        //    origCkt.City = editCkt.City;
        //    origCkt.State = editCkt.State;
        //    origCkt.Zip = editCkt.Zip;
        // }
        // public void Delete(int Id)
        // {
        //     var circuitToDelete = GetById(Id);
        //    _cktList.Remove(circuitToDelete);
        // }
    }
}
