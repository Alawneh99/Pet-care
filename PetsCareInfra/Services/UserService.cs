﻿using Microsoft.EntityFrameworkCore;
using PetsCareCore.DTOs.Login;
using PetsCareCore.DTOs.User;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PetsCareCore.Repos.IUserRepos;

namespace PetsCareInfra.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepos _userRepository;
        private readonly IloginRepos _loginRepository;

        public UserService(IUserRepos userRepository, IloginRepos loginRepository)
        {
            _userRepository = userRepository;
            _loginRepository = loginRepository;
        }

        public async Task<CreateUserDTO> CreateUser(CreateUserDTO createUserDTO)
        {
            try
            {
                // Create a new User entity from the DTO
                var user = new User
                {
                    FirstName = createUserDTO.FirstName,
                    LastName = createUserDTO.LastName,
                    Email = createUserDTO.Email,
                    Phone = createUserDTO.Phone,
                    BirthDate = createUserDTO.BirthDate,
                    ProfileImage = createUserDTO.ProfileImage,
                    UserRoleID = createUserDTO.UserRoleID,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDTO.Password)
                };

                // Add the new User to the database
                var createdUser = await _userRepository.CreateUser(user);

                // Proceed with creating a Login only if the User was successfully created
                if (createdUser != null)
                {
                    // Create a Login object for the new user
                    var login = new Login
                    {
                        UserName = createdUser.Email, // Using email as username
                        Password = user.PasswordHash, // Use the hashed password from user entity
                        UserId = createdUser.Id, // Associate with the created user's ID
                        IsLoggedIn = false,
                        LastLoginTime = DateTime.Now // Set the last login time to the current time
                    };

                    // Save the Login object to the database
                    await _loginRepository.CreateLogin(login);
                }

                // Return the created user's data back as a DTO
                return new CreateUserDTO
                {
                    FirstName = createdUser.FirstName,
                    LastName = createdUser.LastName,
                    Email = createdUser.Email,
                    Phone = createdUser.Phone,
                    BirthDate = createdUser.BirthDate,
                    ProfileImage = createdUser.ProfileImage,
                    UserRoleID = createdUser.UserRoleID
                };
            }
            catch (Exception ex)
            {
                // Throw a new exception with a user-friendly message
                throw new Exception("An error occurred while creating the user. Please try again later.", ex);
            }
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }

        public async Task<IEnumerable<UpdateUserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(user => new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                BirthDate = user.BirthDate,
                ProfileImage = user.ProfileImage,
                UserRoleID = user.UserRoleID
            });

        }

        public async Task<UpdateUserDTO> GetUser(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null) return null;

            return new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                BirthDate = user.BirthDate,
                ProfileImage = user.ProfileImage,
                UserRoleID = user.UserRoleID
            };
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepository.GetUserById(updateUserDTO.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.FirstName = updateUserDTO.FirstName;
            user.LastName = updateUserDTO.LastName;
            user.Email = updateUserDTO.Email;
            user.Phone = updateUserDTO.Phone;
            user.BirthDate = updateUserDTO.BirthDate;
            user.ProfileImage = updateUserDTO.ProfileImage;
            user.UserRoleID = updateUserDTO.UserRoleID;

            await _userRepository.UpdateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }
    }

    }
