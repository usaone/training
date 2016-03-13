﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Controllers
{
    public class PostsController : Controller
    {
        readonly BlogDataContext _dataContext;

        public PostsController(BlogDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);

            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            _dataContext.Posts.Add(post);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Post", new { id = post.Id });
        }

        public IActionResult Post(long id)
        {
            var post = _dataContext.Posts.SingleOrDefault(x => x.Id == id);

            return View(post);
        }

    }
}
