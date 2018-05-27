using SQLite;
using System;

namespace XamarinDiary.Models
{
    public class DiaryPage
    {
        public DiaryPage()
        {
            LastUpdated = DateTime.Now;
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Indexed]
        public string Category { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}