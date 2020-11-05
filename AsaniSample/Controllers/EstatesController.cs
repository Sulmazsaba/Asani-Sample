using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsaniSample.Core.DTOs;
using AsaniSample.Core.Interfaces;
using AsaniSample.Infrastructure.Data.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsaniSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public EstatesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork?? throw new ArgumentNullException(nameof(IUnitOfWork));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        [HttpGet(Name = "GetEstates")]
        public ActionResult<IEnumerable<EstateDto>> GetEstates()
        {
            var estatesFromRepo = unitOfWork.EstateRepository.Get(i=>!i.IsDeleted);
            if (!estatesFromRepo.Any())
                return NotFound();

            return Ok(mapper.Map<IEnumerable<EstateDto>>(estatesFromRepo));
        }
    }
}
