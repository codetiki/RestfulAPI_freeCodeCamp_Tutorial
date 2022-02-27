using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Resources
{
    public class SaveForceTypeResource
    {
        // attribuutteja Required ja MaxLength ASP.NET Core -putki käyttää näitä metatietoja pyyntöjen ja vastausten vahvistamiseen
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
    }
}
