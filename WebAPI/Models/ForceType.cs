using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    // luokka, joka kuvaa ominaisuuksia
    public class ForceType
    {
        // Id ominaisuus luokan tunnistamiseksi, joka on int-tyyppiä
        public int Id { get; set; }
        // Type ominaisuus, joka on string-tyyppiä
        public string Type { get; set; }
        // käyttää Entity Framework Core , ORM,
        // jota useimmat ASP.NET Core -sovellukset käyttävät tietojen säilyttämiseen tietokantaan ForceType:iden ja Result:iden välisen suhteen kartoittamiseen
        public IList<Result> Results { get; set; } = new List<Result>();

    }
}
