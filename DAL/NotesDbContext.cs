using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Notes.DAL.Entities;
using System.Linq;
using Notes.DTO;

namespace Notes.DAL
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }

        public IEnumerable<NoteDto> GetAllNotesSortedByDateOfLastChange()
        {
            //сначала более поздние (по дате изменения)
            return Notes.OrderByDescending(note => note.DateOfLastChange).Select(note => new NoteDto(note));
        }
    }
}