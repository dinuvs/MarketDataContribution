using AutoMapper;
using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.Main.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.Profiles
{
    public class MarketDataProfile: Profile
    {
        public MarketDataProfile()
        {
            CreateMap<MarketData, MarketDataDto>();
            CreateMap<MarketDataDto, MarketData>();
        }
    }
}
