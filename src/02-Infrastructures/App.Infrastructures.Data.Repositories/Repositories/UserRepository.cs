using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            var record = new User
            {
                Name = userDto.Name,
                Family=userDto.Family,
                ImageUrl=userDto.ImageUrl
            };
            await _dbContext.Users.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return record.UserId;
        }

        public async Task Delete(int UserID, string rootpat, CancellationToken cancellationToken)
        {
            var Record = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == UserID, cancellationToken);
            if (Record != null)
            {
                if (Record.ImageUrl != null)
                {
                    var fullPath = Path.Combine(rootpat, "", Record.ImageUrl);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                _dbContext.Users.Remove(Record);
            }
            else
            {
                throw new KeyNotFoundException("کاربر مورد نظر پیدا نشد");
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
        {
            var Record = await _dbContext.Users.Select(x => new UserDto
            {
                UserId=x.UserId,
                Name = x.Name,
                Family=x.Family,
                ImageUrl=x.ImageUrl

            }).ToListAsync((cancellationToken));
            return Record;
        }

        public async Task<UserDto> GetById(int UserId, CancellationToken cancellationToken)
        {

            var Record = await _dbContext.Users.Include(x=>x.UserDetails).FirstOrDefaultAsync(x => x.UserId ==
            UserId, cancellationToken);
            var user = new UserDto
            {
                UserId = Record.UserId,
                Name = Record.Name,
                Family = Record.Family,
                ImageUrl=Record.ImageUrl,
                UserDetails = new UserDetailsDto 
                {
                    UserDetailsId = Record.UserDetails.UserDetailsId,
                    Gender = Record.UserDetails.Gender,
                    Age = Record.UserDetails.Age
                }

            };
            return user;
        }

        public async Task Update(UserDto userDto, CancellationToken cancellationToken)
        {
            var Record = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId ==
            userDto.UserId, cancellationToken);

            Record.Name = userDto.Name;
            Record.Family = userDto.Family;
            Record.ImageUrl = userDto.ImageUrl;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
