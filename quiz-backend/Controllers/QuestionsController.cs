using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return new Models.Question[] {
                new Models.Question() { Text = "hello"},
                new Models.Question() { Text = "asmaa"}
            };
        }

        [HttpPost]
        public void Post([FromBody]Models.Question question)
        {
        }
    }
}
