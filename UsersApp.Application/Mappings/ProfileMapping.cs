using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Application.Commands;
using UsersApp.Application.Queries;
using UsersApp.Domain.Enums;
using UsersApp.Domain.Models;
using UsersApp.Infra.Data.MongoDB.Collections;

namespace UsersApp.Application.Mappings
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<UserCreateCommand, User>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.CreatedAt = DateTime.Now;
                    dest.Status = Status.Active;
                });

            CreateMap<UserCollection, UserDto>();
        }
    }
}
