using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ForceType
    {
        public int Id { get; set; }
        public string Type { get; set; }
       
        public IList<Result> Results { get; set; } = new List<Result>();

    }
}
