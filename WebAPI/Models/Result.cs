using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string LengthL { get; set; }
        public string LengthA { get; set; }
        public string LengthB { get; set; }       
        public string ForceTV { get; set; }
        public string ForcePK { get; set; }
        public string ForcePM { get; set; }
        public string MaxM { get; set; }
        public string MaxV { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }

        // Luokkien 
        public int ForceTypeId { get; set; }
        public ForceType ForceType { get; set; }

        


    }
}
