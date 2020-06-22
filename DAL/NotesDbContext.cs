using Microsoft.EntityFrameworkCore;
using Notes.DAL.Entities;

namespace Notes.DAL
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }
    }
}