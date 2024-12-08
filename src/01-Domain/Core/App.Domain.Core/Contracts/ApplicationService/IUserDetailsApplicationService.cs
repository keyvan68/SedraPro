using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IUserDetailsApplicationService
    {
        Task<int> Create(UserDetailsDto userDetailsDto, CancellationToken cancellationToken);
        Task Delete(int UserDetailsID, CancellationToken cancellationToken);
        Task<UserDetailsDto> GetById(int UserDetailsID, CancellationToken cancellationToken);
        Task Update(UserDetailsDto userDetailsDto, CancellationToken cancellationToken);
    }
}
