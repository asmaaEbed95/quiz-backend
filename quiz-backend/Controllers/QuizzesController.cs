using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizContext _context;
        public QuizzesController(QuizContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Quiz> Get()
        {
            return _context.Quizzes.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quiz quiz)
        {
            _context.Quizzes.Add(quiz);

            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Quiz quizData)
        {
            if (id != quizData.Id)
            {
                return BadRequest();
            }
            _context.Entry(quizData).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(quizData);
        }
    }
}
