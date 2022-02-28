using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CountryModel
    {
        //Dette er get and set metoder der bliver brugt til at trække data fra sql databasen
        public string Land { get; set; }
        public string VerdensDel1 { get; set; }
        public string VerdensDel2 { get; set; }
        public int Rang { get; set; }
        public  decimal FødselsRate { get; set; }
    }
}
