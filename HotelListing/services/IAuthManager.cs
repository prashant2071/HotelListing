using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.services
{
    public interface IAuthManager
    {
        Task<bool> validateUser(LoginUserDTO  userDTO);
        Task<string> CreateToken();

    }
}
