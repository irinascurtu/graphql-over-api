using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedbacks.Api.Data.Entities;
using Feedbacks.Api.Data.Repositories;
using Feedbacks.Api.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feedbacks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackRepository repo;

        public FeedbacksController(FeedbackRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Feedback>> Get()
        {
            return await repo.GetAll();
        }


        [HttpGet]
        [CommaQueryString]
        [Route("multiple")]
        public async Task<IEnumerable<Feedback>> Get([FromQuery]List<int> talks)
        {
            return await repo.GetForIds(talks);
        }


        //[HttpGet("{id}")]      
        //public async Task<Feedback> GetById(int id)
        //{
        //    return await repo.GetById(id);
        //}


        //[HttpGet("{talkId}/talks")]         
        //public async Task<IEnumerable<Feedback>> GetForTalk( int talkId)
        //{
        //    return await repo.GetForTalk(talkId);
        //}


    }
}