﻿using Adapter.Interfaces;
using Domain.Models;
using DTO.DTO;
using System.Collections.Generic;

namespace Adapter.Mapper
{
    public class MapperUser : IMapperUser
    {
        readonly List<UserDTO> userDTOs = new List<UserDTO>();

        public User MapperToEntity(UserDTO item)
        {
            User user = new User
            {
                Id = item.Id,
                Erased = item.Erased,
                Created = item.Created,
                LastUpdate = item.LastUpdate,

                Name = item.Name,
                Email = item.Email,
                Username = item.Username,
                Password = item.Password,
                AccessRole = item.AccessRole
            };

            return user;
        }

        public IEnumerable<UserDTO> MapperToList(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                UserDTO userDTO = new UserDTO
                {
                    Id = item.Id,
                    Erased = item.Erased,
                    Created = item.Created,
                    LastUpdate = item.LastUpdate,

                    Name = item.Name,
                    Email = item.Email,
                    Username = item.Username,
                    Password = item.Password,
                    AccessRole = item.AccessRole
                };

                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public UserDTO MapperToDTO(User item)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = item.Id,
                Erased = item.Erased,
                Created = item.Created,
                LastUpdate = item.LastUpdate,

                Name = item.Name,
                Email = item.Email,
                Username = item.Username,
                Password = item.Password,
                AccessRole = item.AccessRole
            };

            return userDTO;
        }
    }
}
