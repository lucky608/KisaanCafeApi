using AutoMapper;
using KisaanCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Mapper
{
    public class ApiToServiceMapper : Profile
    {
        public ApiToServiceMapper() {
            CreateMap<ProductDetails, ProductCommand>().ReverseMap();
        }
    }
}