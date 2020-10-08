using AutoMapper;
using bd.vienkiemsoat.web.data;
using bd.vienkiemsoat.web.data.Entities;
using bd.vienkiemsoat.web.data.Interfaces;
using bd.vienkiemsoat.web.Model.Models;
using bd.vienkiemsoat.web.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bd.vienkiemsoat.web.service
{
    public class CosoService : ICosoService
    {
        public readonly IGenericRepository<CoSoEntity> _genericRepository;
        private readonly IMapper _mapper;
        public CosoService(IGenericRepository<CoSoEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

       

        public List<CoSoModel> GetAll()
        {
            var vuans = _genericRepository.GetAll().OrderBy(x => x.Index);
            return _mapper.Map<List<CoSoModel>>(vuans);
        }
    }
}
