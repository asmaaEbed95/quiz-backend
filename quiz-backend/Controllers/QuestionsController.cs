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
    public class QuestionsController : ControllerBase
    {
        private readonly QuizContext _context;
        public QuestionsController (QuizContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _context.Questions.ToList();
        }

        [HttpGet("{quizId}")]
        public IEnumerable<Question> Get([FromRoute] int quizId)
        {
            return _context.Questions.Where(q => q.QuizId == quizId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Question question)
        {
            var quiz = _context.Quizzes.SingleOrDefault(q => q.Id == question.QuizId);
            if (quiz == null)
            {
                return NotFound();
            }
            _context.Questions.Add(question);

            await _context.SaveChangesAsync();

            return Ok(question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question questionData)
        {
            if (id != questionData.Id)
            {
                return BadRequest();
            }
            _context.Entry(questionData).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(questionData);
        }
    }
}
