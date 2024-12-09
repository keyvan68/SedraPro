using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class UserDetailsRepositiry : IUserDetailsRepositiry
    {
        private readonly AppDbContext _dbContext;

        public UserDetailsRepositiry(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserDetailsDto userDetailsDto, CancellationToken cancellationToken)
        {
            var record = new UserDetails
            {
                Age = userDetailsDto.Age,
                Gender = userDetailsDto.Gender
            };
            await _dbContext.UserDetails.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return record.UserDetailsId;
        }

        public async Task Delete(int UserDetailsID, CancellationToken cancellationToken)
        {
            var Record = await _dbContext.UserDetails.FirstOrDefaultAsync(x => x.UserDetailsId == UserDetailsID, cancellationToken);
            if (Record != null)
            {
                _dbContext.UserDetails.Remove(Record);
            }
            else
            {
                throw new KeyNotFoundException("اطلاعات کاربر مورد نظر پیدا نشد ");
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task<UserDetailsDto> GetById(int UserDetailsID, CancellationToken cancellationToken)
        {
            var Record = await _dbContext.UserDetails
                .FirstOrDefaultAsync(x => x.UserDetailsId == UserDetailsID, cancellationToken);
            if (Record != null)
            {
                var userDetail = new UserDetailsDto
                {
                    UserDetailsId = Record.UserDetailsId,
                    Age = Record.Age,
                    Gender = Record.Gender,
                };
                return userDetail;

            }
            else
            {
                throw new KeyNotFoundException("اطلاعات کاربر مورد نظر پیدا نشد ");
            }
        }

        public async Task Update(UserDetailsDto userDetailsDto, CancellationToken cancellationToken)
        {
            var Record = await _dbContext.UserDetails.FirstOrDefaultAsync(x => x.UserDetailsId ==
            userDetailsDto.UserDetailsId, cancellationToken);

            Record.Age = userDetailsDto.Age;
            Record.Gender = userDetailsDto.Gender;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
