using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Notes.DAL;
using Notes.DAL.Entities;

namespace Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _db;

        public NotesController(NotesDbContext context)
        {
            _db = context;
        }

        [HttpGet("")]
        public IEnumerable<Note> GetAllNotes()
        {
            Console.WriteLine("обрабатываю HttpGet-запрос api/notes");

            return _db.GetAllNotesSortedByDateOfLastChange();
        }

        [HttpPost("create")]
        public void CreateNote([FromForm] Note noteFromClient)
        {
            Console.WriteLine("обрабатываю HttpPost-запрос api/notes/create входные данные: \n" +
                              $"Title='{noteFromClient.Title}', " +
                              $"Content='{noteFromClient.Content}'");

            var title = string.IsNullOrEmpty(noteFromClient.Title) ? null : noteFromClient.Title;
            var newNote = new Note(title, noteFromClient.Content);

            _db.Notes.Add(newNote);
            _db.SaveChanges();
        }

        [HttpPut("change")]
        public void ChangeNote([FromForm] Note noteFromClient)
        {
            Console.WriteLine("обрабатываю HttpPut-запрос api/notes/change, входные данные: \n" +
                              $"Id='{noteFromClient.Id}', " +
                              $"Title='{noteFromClient.Title}', " +
                              $"Content='{noteFromClient.Content}'");

            var noteFromDb = _db.Notes.First(note => note.Id == noteFromClient.Id);

            var title = string.IsNullOrEmpty(noteFromClient.Title) ? null : noteFromClient.Title;
            noteFromDb.Title = title;
            noteFromDb.Content = noteFromClient.Content;
            noteFromDb.DateOfLastChange = DateTime.Now;

            _db.SaveChanges();
        }

        [HttpDelete("delete/{noteId}")]
        public void DeleteNoteById(int noteId)
        {
            Console.WriteLine($"обрабатываю HttpDelete-запрос api/notes/delete/{noteId}");

            var noteFromDb = _db.Notes.First(note => note.Id == noteId);

            _db.Notes.Remove(noteFromDb);
            _db.SaveChanges();
        }

        [HttpGet("contains")]
        public IEnumerable<Note> GetBySubstring()
        {
            Console.WriteLine("обрабатываю запрос api/notes/contains с пустой строкой");
        
            return _db.GetAllNotesSortedByDateOfLastChange();
        }

        [HttpGet("contains/{substring}")]
        public IEnumerable<Note> GetBySubstring(string substring)
        {
            Console.WriteLine($"обрабатываю HttpGet-запрос api/notes/contains/{substring}");

            var lowerSubstring = substring.ToLower();

            return _db.GetAllNotesSortedByDateOfLastChange()
                .Where(note => note.Title != null && note.Title.ToLower().Contains(lowerSubstring) ||
                               note.Content.ToLower().Contains(lowerSubstring));
        }
    }
}