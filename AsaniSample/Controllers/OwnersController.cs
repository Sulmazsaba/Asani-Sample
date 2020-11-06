using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsaniSample.Core.DTOs;
using AsaniSample.Core.Entities;
using AsaniSample.Infrastructure.Data.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsaniSample.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public OwnersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet(Name = "GetOwners")]
        public ActionResult<IEnumerable<OwnerDto>> GetOwners()
        {
            var ownersFromRepo = unitOfWork.OwnerRepository.Get();
            return Ok(mapper.Map<IEnumerable<OwnerDto>>(ownersFromRepo));
        }
    }
}
