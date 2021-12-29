using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, FilmeModel>();
            CreateMap<FilmeModel, ReadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, FilmeModel>();
        }
    }
}
