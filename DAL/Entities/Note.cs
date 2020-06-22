using System;

namespace Notes.DAL.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfLastChange { get; set; }

        public Note(string content)
        {
            Content = content;
        }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}