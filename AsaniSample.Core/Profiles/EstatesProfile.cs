using System;
using System.Collections.Generic;
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
            CreateMap<Estate, EstateDto>();
        }
    }
}
