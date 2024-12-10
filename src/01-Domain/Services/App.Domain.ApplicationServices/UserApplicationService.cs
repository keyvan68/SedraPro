using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailsRepositiry _userDetailsRepositiry;

        public UserApplicationService(IUserRepository userRepository, IUserDetailsRepositiry userDetailsRepositiry = null)
        {
            _userRepository = userRepository;
            _userDetailsRepositiry = userDetailsRepositiry;
        }

        public async Task<int> Create(UserDto userDto, IFormFile file, string rootpath, CancellationToken cancellationToken)
        {
            int Id = 0;
            if (file != null)
            {

                var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                var path = Path.Combine(rootpath, @"Images\User", filename);
                using (var stream = File.Create(path))
                {
                    file.CopyTo(stream);
                }
                userDto.ImageUrl = @"Images\User\" + filename;
            }
            Id = await _userRepository.Create(userDto, cancellationToken);

            userDto.UserDetails.UserDetailsId = Id;
            await _userDetailsRepositiry.Create(userDto.UserDetails, cancellationToken);
            return Id;
        }

        public async Task Delete(int UserID, string rootpath, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(UserID, rootpath, cancellationToken);
        }

        public async Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll(cancellationToken);
        }

        public async Task<UserDto> GetById(int UserId, CancellationToken cancellationToken)
        {
            return await _userRepository.GetById(UserId, cancellationToken);
        }

        public async Task Update(UserDto userDto, IFormFile file, string rootpath, CancellationToken cancellationToken)
        {
            if (file != null)
            {
                if (userDto.ImageUrl != null)
                {
                    var fullPath = Path.Combine(rootpath, "", userDto.ImageUrl);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }

                var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                var path = Path.Combine(rootpath, @"Images\User", filename);
                using (var stream = File.Create(path))
                {
                    file.CopyTo(stream);
                }
                userDto.ImageUrl = @"Images\User\" + filename;


            }
            //var fileName = "";
            //fileName = imageUrl;

            await _userRepository.Update(userDto, cancellationToken);
            await _userDetailsRepositiry.Update(userDto.UserDetails, cancellationToken);
        }
    }
}
