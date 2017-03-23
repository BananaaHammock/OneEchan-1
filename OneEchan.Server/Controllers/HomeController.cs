﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneEchan.Server.Data;
using cloudscribe.Web.Pagination;
using cloudscribe.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace OneEchan.Server.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly ISiteContext _currentSite;
        private const int PAGE_SIZE = 20;

        public HomeController(ApplicationDbContext context, SiteContext currentSite)
        {
            _context = context;
            _currentSite = currentSite;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("AllContent")]
        public IActionResult AllContent(int page = 0)
        {
            return View(_context.Post.Where(item => item.SiteId == _currentSite.Id).OrderByDescending(item => item.CreatedAt).ToPagedList(page, PAGE_SIZE));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
