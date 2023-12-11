using AutoMapper;
using KisaanCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Mapper
{
    public class RepoToServiceMapper : Profile
    {
        public RepoToServiceMapper() {
            CreateMap<ProductCommand, ProductDetails>().ReverseMap();
        }
    }
}