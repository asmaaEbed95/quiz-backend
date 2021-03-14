using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Models
{
    public class QuizContext : IdentityDbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base (options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Credentials> credentials { get; set; }
    }
}
