using AutoMapper;
using Karimaneh.Application.Features.RefreshTokens.DTOs;
using Karimaneh.Domain.Entities;

namespace Karimaneh.Application.Features.RefreshTokens.Mappings
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshToken, RefreshTokenDto>();
        }
    }
}
