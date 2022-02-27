using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ResultService(IResultRepository resultRepository, IUnitOfWork unitOfWork)
        {
            _resultRepository = resultRepository;
            // voidaan merkitä kahdella tapaa: this.forceTypeService = _forceTypeService
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Result>> ListAsync()
        {
            return await _resultRepository.ListAsync();
        }
    }
   
}
