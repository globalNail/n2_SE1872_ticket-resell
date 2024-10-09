using AutoMapper;
using Repository.DTOs.Wallet;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class MapperConfigProfile: Profile
    {
        public MapperConfigProfile() 
        {
            CreateMap<WalletDTOResponse, Wallet>().ReverseMap();
        }
       
    }
}
