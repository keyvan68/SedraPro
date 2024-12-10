using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.UserDtoModels
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string? ImageUrl { get; set; }
        //public UserDetailsDto UserDetail { get; set; }
        public UserDetailsDto UserDetails { get; set; }
    }
}
