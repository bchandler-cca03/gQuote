using CktMgr.CircuitLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CktMgr.Models
{
    public class SearchViewModel
    {

        public SearchModel SearchModel { get; set; }

        public List<Circuit> Circuits { get; set; }

        public int PageNumber { get; set; }

    }
}
