using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using ServerApp.Data;
using ServerApp.DTO;
using AutoMapper;

namespace ServerApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly ISocialRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(ISocialRepository repository, IMapper mapper)
        {
            _repository=repository;
            _mapper = mapper;
        }
        
        //api/users
public async Task<IActionResult> GetUsers(){
    var users =await _repository.GetUsers();
    var result = _mapper.Map<IEnumerable<UserForListDTO>>(users);
    return Ok(result);
}
//api/users/5
[HttpGet("{id}")]
public async Task<IActionResult> GetUser(int id){
    var user = await _repository.GetUsers(id);
    var result= _mapper.Map<UserForDetailsDTO>(user);
    return Ok(result);
}
    }
} 