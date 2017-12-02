﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TeamStore.Keeper.Interfaces;
using TeamStore.DevUI.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TeamStore.DevUI.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly IApplicationIdentityService _applicationIdentityService;
        public ReportsController(
            IApplicationIdentityService applicationIdentityService
            )
        {
            _applicationIdentityService = applicationIdentityService ?? throw new ArgumentNullException(nameof(applicationIdentityService));
        }

        /// <summary>
        /// Check if the current user is a SystemAdministrator
        /// </summary>
        /// <returns>True if the current user is a SystemAdministrator.</returns>
        private async Task<bool> ValidateSystemAdministrator()
        {
            return await _applicationIdentityService.IsCurrentUserAdmin();
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            if (await ValidateSystemAdministrator() == false)
            {
                return Unauthorized();
            }

            var reportsListViewModel = new ReportsViewModel();
            reportsListViewModel.Reports.Add("Credential Access", "CredentialAccess");
            reportsListViewModel.Reports.Add("User Logins", "UserLogins");

            return View(reportsListViewModel);
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (await ValidateSystemAdministrator() == false)
            {
                return Unauthorized();
            }

            if (id == null)
            {
                return NotFound();
            }
            
            return View();
        }
    }
}
