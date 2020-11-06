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
    [Route("api/owners/{ownerId}/estates")]
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
        public ActionResult<IEnumerable<EstateDto>> GetEstates(Guid ownerId)
        { 
            var existOwner = unitOfWork.OwnerRepository.Get(ownerId)!=null;
            if (!existOwner)
                return NotFound();

            var estatesFromRepo = unitOfWork.EstateRepository.Get(i=>!i.IsDeleted&&i.OwnerId==ownerId);
            return Ok(mapper.Map<IEnumerable<EstateDto>>(estatesFromRepo));
        }

        [HttpGet("{id}",Name = "GetEstateForOwner")]
        public ActionResult<EstateDto> GetEstateForOwner(Guid ownerId,Guid id)
        {
            var existOwner = unitOfWork.OwnerRepository.Get(ownerId)!=null;
            if (!existOwner)
                return NotFound();

            var entity=unitOfWork.EstateRepository.GetEstate(id);
            if (entity == null)
                return NotFound();

            return Ok(mapper.Map<EstateDto>(entity));
        }


        [HttpPost]
        public ActionResult<EstateDto> CreateEstateForOwner(Guid ownerId,EstateForManipulationDto dto)
        {
            var existOwner = unitOfWork.OwnerRepository.Get(ownerId)!=null;
            if (!existOwner)
                return NotFound();

            var entity = mapper.Map<Estate>(dto);
            unitOfWork.EstateRepository.AddEstate(entity);
            unitOfWork.Commit();

            var estateToReturn = mapper.Map<EstateDto>(entity);

            return CreatedAtRoute("GetEstateForOwner",
                new {ownerId,id=entity.Id },
                estateToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstateForOwner(Guid ownerId,Guid id)
        {

            var existOwner = unitOfWork.OwnerRepository.Get(ownerId)!=null;
            if (!existOwner)
                return NotFound();

            var entity = unitOfWork.EstateRepository.GetFirstOrDefault(i => i.Id == id);
            if (entity == null)
                return NotFound();


            unitOfWork.EstateRepository.RemoveLogicalEstate(entity);
            unitOfWork.Commit();

            return NoContent();
        }

        [HttpPut("{estateId}")]
        public IActionResult UpdateEstateForOwner(Guid ownerId, Guid estateId, 
            EstateForManipulationDto dto)
        {
            var existOwner = unitOfWork.OwnerRepository.Get(ownerId)!=null;
            if (!existOwner)
                return NotFound();
            
            var entity = unitOfWork.EstateRepository.Get(estateId);
            if (entity == null)
                return NotFound();

            mapper.Map(dto, entity);
            unitOfWork.EstateRepository.Update(entity);
            unitOfWork.Commit();

            return NoContent();
        }


    }
}
