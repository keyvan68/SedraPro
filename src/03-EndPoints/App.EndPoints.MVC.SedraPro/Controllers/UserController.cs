﻿using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.EndPoints.MVC.SedraPro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.SedraPro.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userApplicationService;
        private readonly IUserDetailsApplicationService _userDetailsApplicationService;

        public UserController(IUserApplicationService userApplicationService, IUserDetailsApplicationService userDetailsApplicationService)
        {
            _userApplicationService = userApplicationService;
            _userDetailsApplicationService = userDetailsApplicationService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {

            var UserList = await _userApplicationService.GetAll(cancellationToken);
            var users = UserList.Select(u => new UserViewModel
            {
                UserId = u.UserId,
                Name = u.Name,
                Family = u.Family

            }).ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //    return PartialView("_Create", new UserViewModel());

            //return View(new UserViewModel());
            return PartialView("_Create", new UserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return PartialView("_Create", model);

            var dto = new UserDto
            {
                UserId = model.UserId,
                Name = model.Name,
                Family = model.Family
            };

            await _userApplicationService.Create(dto, cancellationToken);
            return Json(new { success = true });


        }
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            await _userApplicationService.Delete(Id, cancellationToken);
            return Json(new { success = true });
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id, CancellationToken cancellationToken)
        {
            var Record = await _userApplicationService.GetById(Id, cancellationToken);
            var User = new UserViewModel
            {
                UserId = Record.UserId,
                Name = Record.Name,
                Family = Record.Family
            };


            return PartialView("_Update", User);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var User = new UserDto
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    Family = model.Family
                };
                await _userApplicationService.Update(User, cancellationToken);

            }
            return Json(new { success = true });
            //return RedirectToAction("Index");
        }
        public async Task<IActionResult> UserDetails(int id ,CancellationToken cancellationToken)
        {
            var UserDetail = await _userDetailsApplicationService.GetById(id, cancellationToken);
            var users =  new UserDeailViewModel
            {
                Age= UserDetail.Age,
                Gender=UserDetail.Gender

            };
            return View(users);
        }
    }
}