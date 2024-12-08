using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
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

        public UserApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            int Id = await _userRepository.Create(userDto, cancellationToken);
            return Id;
        }

        public async Task Delete(int UserID, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(UserID, cancellationToken);
        }

        public async Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll(cancellationToken);
        }

        public async Task<UserDto> GetById(int UserId, CancellationToken cancellationToken)
        {
            return await _userRepository.GetById(UserId, cancellationToken);
        }

        public async Task Update(UserDto userDto, CancellationToken cancellationToken)
        {
            await _userRepository.Update(userDto, cancellationToken);
        }
    }
}
