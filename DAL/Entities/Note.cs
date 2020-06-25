using System;

namespace Notes.DAL.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = null!;
        public DateTime DateOfLastChange { get; set; } = DateTime.Now;

        public Note()
        {
        }

        public Note(string? title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}