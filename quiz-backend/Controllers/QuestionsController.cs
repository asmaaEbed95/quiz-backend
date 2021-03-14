﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Question question)
        {
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
