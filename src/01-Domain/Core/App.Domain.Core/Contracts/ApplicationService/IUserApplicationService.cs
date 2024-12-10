using App.Domain.Core.DtoModels.UserDtoModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IUserApplicationService
    {
        Task<int> Create(UserDto userDto, IFormFile file, string rootpath, CancellationToken cancellationToken);
        Task Delete(int UserID, string rootpath, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAll(CancellationToken cancellationToken);
        Task<UserDto> GetById(int UserId, CancellationToken cancellationToken);
        Task Update(UserDto userDto, IFormFile file, string rootpath, CancellationToken cancellationToken);
    }
}
