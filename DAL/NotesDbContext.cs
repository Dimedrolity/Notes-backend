using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Notes.DAL.Entities;
using System.Linq;

namespace Notes.DAL
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }

        public IEnumerable<Note> GetAllNotesSortedByDateOfLastChange()
        {
            //сначала более поздние (по дате изменения)
            return Notes.OrderByDescending(note => note.DateOfLastChange);
        }
    }
}