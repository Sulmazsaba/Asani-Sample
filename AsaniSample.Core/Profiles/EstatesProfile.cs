using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsaniSample.Core.DTOs;
using AsaniSample.Core.Entities;
using AutoMapper;

namespace AsaniSample.Core.Profiles
{
   public class EstatesProfile :Profile
    {
        public EstatesProfile()
        {
         
            CreateMap<Estate, EstateDto>().ForMember(dest=>dest.OwnerName,
            opt=>opt.MapFrom(src=>src.Owner.FirstName + " " + src.Owner.LastName));
            CreateMap<EstateForCreationDto, Estate>();
        }
    }
}
