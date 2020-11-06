using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsaniSample.Core.DTOs;
using AsaniSample.Core.Entities;
using AsaniSample.Core.Helpers;
using AutoMapper;

namespace AsaniSample.Core.Profiles
{
   public class EstatesProfile :Profile
    {
        public EstatesProfile()
        {
         
            CreateMap<Estate, EstateDto>()
                .ForMember(dest=>dest.OwnerName,
            opt=>
                opt.MapFrom(src=>src.Owner.FirstName + " " + src.Owner.LastName))

                .ForMember(dest => dest.Type,
                opt =>
                    opt.MapFrom(src => src.Type.GetDescription()))
                .IncludeMembers(src=>src.Owner);

            CreateMap<EstateForManipulationDto, Estate>();
        }
    }
}
