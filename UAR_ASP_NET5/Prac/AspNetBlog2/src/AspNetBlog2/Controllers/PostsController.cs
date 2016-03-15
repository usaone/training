using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog2.Controllers
{
    public class PostsController : Controller
    {
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
        public IActionResult Create(Post post)
        {
            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            return View();
        }

        //[HttpPost]
        //public IActionResult Create([Bind("Title", "Body")]Post post) //too difficult to maintain when we add more parameters
        //{
        //    post.PostedDate = DateTime.Now;
        //    post.Author = User.Identity.Name;

        //    return View();
        //}

        //public class CreatePostRequest
        //{
        //    public string Title { get; set; }
        //    public string Body { get; set; }
        //}

        //[HttpPost]
        //public IActionResult Create(CreatePostRequest request)
        //{
        //    var post = new Post();
        //    post.Title = request.Title;
        //    post.Body = request.Body;
        //    post.PostedDate = DateTime.Now;
        //    post.Author = User.Identity.Name;

        //    return View();
        //}

        public IActionResult Post(long id)
        {
            var post = new Post();

            post.Title = "Uddip's Blog Post";
            post.PostedDate = DateTime.Now;
            post.Author = "Uddip Mitra";
            post.Body = "This is my first blog post about ASP.NET MVC 6!";

            return View(post);
        }

    }
}
