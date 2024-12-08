using App.Domain.Core.DtoModels.UserDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IUserApplicationService
    {
        Task<int> Create(UserDto userDto, CancellationToken cancellationToken);
        Task Delete(int UserID, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAll(CancellationToken cancellationToken);
        Task<UserDto> GetById(int UserId, CancellationToken cancellationToken);
        Task Update(UserDto userDto, CancellationToken cancellationToken);
    }
}
