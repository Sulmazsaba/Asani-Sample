using System;
using System.Collections.Generic;
using System.Text;
using AsaniSample.Core.DTOs;
using AsaniSample.Core.Entities;
using AutoMapper;

namespace AsaniSample.Core.Profiles
{
  public  class OwnersProfile : Profile
    {
        public OwnersProfile()
        {
            CreateMap<Owner,OwnerDto>().ForMember(dest=>dest.FullName,
                opt=>
                    opt.MapFrom(src=>src.FirstName + " "+src.LastName));
              
          
        }
    }
}
