using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Resources;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    public class ResultsController : Controller
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public ResultsController(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            // voidaan merkitä kahdella tapaa: this.forceTypeService = _forceTypeService
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ResultResource>> GetAllAsync()
        {
            var results = await _resultService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Result>, IEnumerable<ResultResource>>(results);

            return resources;
        }
    }
}
