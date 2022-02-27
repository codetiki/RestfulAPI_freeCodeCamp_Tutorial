using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Communication;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IForceTypeService
    {
        // Menetelmän toteutusten ListAsync on palautettava asynkronisesti kuormatyyppien (ForceType) luettelo.
        // dependency injection =  voimme toteuttaa nämä rajapinnat ja eristää ne muista komponenteista.
        // Periaatteessa, kun käytät riippuvuuslisäystä,
        // määrität jotkin käyttäytymiset käyttöliittymän avulla.Sitten luot luokan, joka toteuttaa käyttöliittymän.
        // Lopuksi sido käyttöliittymän viitteet luomaasi luokkaan.
        Task<IEnumerable<ForceType>> ListAsync();
        Task<SaveForceTypeResponse> SaveAsync(ForceType forceType);
        Task<SaveForceTypeResponse> UpdateAsync(int id, ForceType forceType);
        Task<SaveForceTypeResponse> DeleteAsync(int id);
    }
}
