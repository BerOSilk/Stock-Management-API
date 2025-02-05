using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces{

    public interface ITokenService{
        public string CreateToken(AppUser user);
    }

}