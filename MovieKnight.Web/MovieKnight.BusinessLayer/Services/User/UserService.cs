using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Exceptions;
using MovieKnight.BusinessLayer.Services.EmailService;
using MovieKnight.DataLayer.Builders.UserSearchQueryBuilder;
using MovieKnight.DataLayer.Enums;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserSearchQueryBuilder _userSearchQueryBuilder;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, UserManager<AppUser> userManager,
            IEmailService emailService, IUserSearchQueryBuilder userSearchQueryBuilder,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userSearchQueryBuilder = userSearchQueryBuilder;
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<IEnumerable<AppUser>> SearchUsers(string username)
        {
            var result =
                 _userSearchQueryBuilder.SetBaseUserInfo()
                .SetUsername(username)
                .Build()
                .ToList();

            return result;
        }

        public async Task<AppUser> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserWithWatchHistory(username);
        }

        public async Task<AppUser> CreateUserAsync(CreateUserDto model)
        {
            AppUser existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
            {
                throw new UsernameAlreadyTakenException();
            }

            AppUser user = _mapper.Map<AppUser>(model);
            user.RegistryDate = DateTime.Now;
            IdentityResult addUserResult = await _userManager.CreateAsync(user, model.Password);

            ValidateIdentityResult(addUserResult);

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var param = new Dictionary<string, string>
                {
                    {"token", token },
                    {"email", user.Email }
                };
            string url = QueryHelpers.AddQueryString(model.ClientURIForEmailConfirmation, param);
            await _emailService.SendEmail(user, url);


            return await GetUserByUsername(user.UserName);
        }

        public async Task<ConfirmEmailDto> ConfirmEmail(ConfirmEmailDto confirmEmailDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(confirmEmailDto.Email);
            if (user == null)
                return null;
            var confirmResult = await _userManager.ConfirmEmailAsync(user, confirmEmailDto.Token);
            if (!confirmResult.Succeeded)
                return null;
            return confirmEmailDto;
        }

        public async Task<bool> UpdateWatchHistoryVisibilityStatus(string userName, StoryVisibility storyVisibility)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            user.StoryVisibility = storyVisibility;
            try
            {
                await _userManager.UpdateAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<AppUser> UpdateUserAsync(UpdateUserDto model)
        {
            List<string> errors = new List<string>();
            Boolean result = ValidatePasswords(model, out errors);

            if (!result)
            {
                throw new InvalidUserPasswordException(String.Join(" ", errors));
            }

            AppUser existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null && existingUser.Id != model.Id)
            {
                throw new UsernameAlreadyTakenException();
            }

            AppUser user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _mapper.Map(model, user);

            IdentityResult updateUserResult = await _userManager.UpdateAsync(user);
            ValidateIdentityResult(updateUserResult);

            if (!String.IsNullOrEmpty(model.NewPassword))
            {
                IdentityResult changePasswordsResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                if (!changePasswordsResult.Succeeded)
                {
                    throw new InvalidUserPasswordException(String.Join(" ", errors));
                }
            }

            return await GetUserByUsername(user.UserName);
        }

        public async Task DeleteUser(Guid userId)
        {
            AppUser userToDelete = await _userManager.FindByIdAsync(userId.ToString());
            IdentityResult deleteUserResult = await _userManager.DeleteAsync(userToDelete);

            ValidateIdentityResult(deleteUserResult);
        }

        private static void ValidateIdentityResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                String errorsMessage = result.Errors
                                         .Select(er => er.Description)
                                         .Aggregate((i, j) => i + ";" + j);
                throw new Exception(errorsMessage);
            }
        }


        private static bool ValidatePasswords(UpdateUserDto model, out List<String> errors)
        {
            errors = new List<string>();
            if (String.IsNullOrEmpty(model.Password) &&
                String.IsNullOrEmpty(model.NewPassword) &&
                String.IsNullOrEmpty(model.ConfirmPassword))
            {
                return true;
            }

            if (String.IsNullOrEmpty(model.Password) ||
                String.IsNullOrEmpty(model.NewPassword) ||
                String.IsNullOrEmpty(model.ConfirmPassword))
            {
                errors.Add(ErrorMessagesConstants.NOT_ALL_PASS_FIELDS_FILLED);
            }

            if (!model.NewPassword.Equals(model.ConfirmPassword))
            {
                errors.Add(ErrorMessagesConstants.PASSWORDS_DO_NOT_MATCH);
            }

            return !errors.Any();
        }
    }
}
