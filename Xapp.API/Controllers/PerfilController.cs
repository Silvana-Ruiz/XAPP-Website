﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xapp.API.Data;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Xapp.Domain.DTOs;
using Xapp.Domain.Entities;

namespace Xapp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly DbService _db;

        public PerfilController(DbService db)
        {
            _db = db;
        }
        

        [HttpPost("login")]

        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(m => m.Email == email && m.Password == password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                
                return Ok();
            } 
        }

        [HttpGet("getPerfil")]
        public async Task<IActionResult> getPerfil(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(m => m.Email == email);
            var perfil = await _db.Perfiles.FirstOrDefaultAsync(m => m.Id == user.UserId);
            if (perfil != null)
            {
                return Ok(perfil);
            }
            else
            {

                return Ok();
            }
        }

        [HttpPut("putPerfil")]
        public async Task<IActionResult> putPerfil(string email, Perfil actualizacion)
        {
            var user = await _db.Users.FirstOrDefaultAsync(m => m.Email == email);
            var perfil = await _db.Perfiles.FirstOrDefaultAsync(m => m.Id == user.UserId);
            if (perfil != null)
            {
                perfil = actualizacion;
                _db.Update(perfil);
                _db.SaveChanges();
                return Ok(perfil);
            }
            else
            {
                return Ok();
            }
        }
    }
}
