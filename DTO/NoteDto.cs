using System;
using Notes.DAL.Entities;

namespace Notes.DTO
{
    public class NoteDto
    {
        public int Id { get; }
        public string? Title { get; }
        public string Content { get; } 
        public string DateOfLastChange { get; }

        public NoteDto(Note note)
        {
            Id = note.Id;
            Title = note.Title;
            Content = note.Content;
            DateOfLastChange = ConvertDateTimeToReadableString(note.DateOfLastChange);
        }

        private string ConvertDateTimeToReadableString(DateTime dateTime)
        {
            if (dateTime.Date == DateTime.Today)
                return $"Сегодня, {dateTime:H:mm}";

            var yesterday = DateTime.Today.AddDays(-1);

            if (dateTime.Date == yesterday)
                return $"Вчера, {dateTime:H:mm}";

            if (dateTime.Year == DateTime.Now.Year)
                return $"{dateTime.Day} {dateTime:MMM} {dateTime:H:mm}";

            return $"{dateTime.Day} {dateTime:MMM} {dateTime.Year} {dateTime:H:mm}";
        }
    }
}