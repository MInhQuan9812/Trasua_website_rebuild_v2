﻿using Microsoft.AspNetCore.Mvc;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Facade;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class PaymentController:Controller
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;

        public PaymentController(TraSuaContext context,IConfiguration configuration)
        {
            _context= context;
            _configuration = configuration;
            _worker =new Worker(_context, _configuration);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success(string paymentId,string token,string payerId)
        {
            ViewData["PaymentId"] = paymentId;
            ViewData["Token"]= token;
            ViewData["PayerId"] = payerId;

            return View();
        }


        public async Task<IActionResult> RedirectApprovalUrl(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    return Redirect(url);
                }
                else
                {
                    throw new Exception("Error to initial Payment");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
