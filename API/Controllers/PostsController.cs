using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Mocrosoft.AspNetCore.Mvc;
using Persistence; 


namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {

        private readonly DataContext context;

        public PostsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetPosts")]

        public ActionResult<List<Post>> Get()
        {
            return this.context.Posts.ToList();
        }
        
    }
}