﻿using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : Controller
    {
        private IAdminService _service;
        private IMapper _map;

        public AdminsController(IMapper CustomMapperAPI, IAdminService adminService)
        {
            _service = adminService;
            _map = CustomMapperAPI;
        }

        //api/admins/42
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            _service.DeleteAdmin(id);
            return NoContent();
        }

        //api/admins/42
        [HttpPatch("{id}")]
        public IActionResult RestoreAdmin(int id)
        {
            _service.RestoreAdmin(id);
            return Ok();
        }

        //api/admins/42
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] AdminUpdateInputModel admin)
        {
            _service.UpdateAdmin(id, _map.Map<AdminModel>(admin));
            return NoContent();
        }

        [HttpPost]
        public ActionResult<AdminOutputModel> AddAdmin([FromBody] AdminInsertInputModel admin)
        {
            _service.AddAdmin(_map.Map<AdminModel>(admin));
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/admins/42
        [HttpGet("{id}")]
        public ActionResult<AdminOutputModel> GetAdminById(int id)
        {
            var admin = _map.Map<AdminOutputModel>(_service.GetAdminById(id));
            return Ok(admin);
        }

        //api/admins
        [HttpGet]
        public ActionResult<List<AdminOutputModel>> GetAllAdmins()
        {
            var admins = _map.Map<List<AdminOutputModel>>(_service.GetAllAdmins());
            return Ok(admins);
        }
    }
}
