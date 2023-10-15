using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
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

/// <summary>
/// my GET api
/// </summary>
/// <returns>Get all posts</returns>
        [HttpGet(Name = "GetPosts")]

        public ActionResult<List<Post>> Get()
        {
            return this.context.Posts.ToList();
        }

/// <summary>
/// My GET BY ID api
/// </summary>
/// <param name="id"></param>
/// <returns>get a single post by ID</returns>

        [HttpGet("{id}", Name = "GetById")]

        public ActionResult<Post> GetById(Guid id)
        {
            var post = this.context.Posts.Find(id);
            if(post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        
    }
}