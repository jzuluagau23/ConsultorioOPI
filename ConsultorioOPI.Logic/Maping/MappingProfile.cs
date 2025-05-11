using AutoMapper;
using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Domain.Entities;
using ConsultorioOPI.Repository.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Logic.Maping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Medico, MedicoDto>().ReverseMap();
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<Turno, TurnoDto>().ReverseMap();
            CreateMap<TurnoMedicoPacienteEntity, TurnoMedicoPacienteDto>().ReverseMap();

            CreateMap<MedicoDto, Medico>().ReverseMap();
            CreateMap<PacienteDto, Paciente>().ReverseMap();
            CreateMap<TurnoDto, Turno>().ReverseMap();
        }
    }
}
