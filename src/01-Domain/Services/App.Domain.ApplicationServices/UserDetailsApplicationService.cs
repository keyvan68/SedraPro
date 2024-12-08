using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class UserDetailsApplicationService : IUserDetailsApplicationService
    {
        private readonly IUserDetailsRepositiry _userDetailsRepositiry;

        public UserDetailsApplicationService(IUserDetailsRepositiry userDetailsRepositiry)
        {
            _userDetailsRepositiry = userDetailsRepositiry;
        }

        public async Task<int> Create(UserDetailsDto userDetailsDto, CancellationToken cancellationToken)
        {
            int Id = await _userDetailsRepositiry.Create(userDetailsDto, cancellationToken);
            return Id;
        }

        public async Task Delete(int UserDetailsID, CancellationToken cancellationToken)
        {
            await _userDetailsRepositiry.Delete(UserDetailsID, cancellationToken);
        }

        public async Task<UserDetailsDto> GetById(int UserDetailsID, CancellationToken cancellationToken)
        {
            return await _userDetailsRepositiry.GetById(UserDetailsID, cancellationToken);
        }

        public async Task Update(UserDetailsDto userDetailsDto, CancellationToken cancellationToken)
        {
            await _userDetailsRepositiry.Update(userDetailsDto, cancellationToken);
        }
    }
}
