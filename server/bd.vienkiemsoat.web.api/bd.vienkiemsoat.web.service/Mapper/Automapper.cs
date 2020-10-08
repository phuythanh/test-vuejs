using AutoMapper;
using bd.vienkiemsoat.web.data;
using bd.vienkiemsoat.web.data.Entities;
using bd.vienkiemsoat.web.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace bd.vienkiemsoat.web.service.Mapper
{
    class AutoMapper : Profile
    {
        public AutoMapper()
        {           
            CreateMap<CoSoEntity, CoSoModel>().ReverseMap();        

        }
    }
}
