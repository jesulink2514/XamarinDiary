using System;

namespace XamarinDiary.Models
{
    public class DiaryPage
    {
        public DiaryPage()
        {
            Id = Guid.NewGuid().ToString();
            LastUpdated = DateTime.Now;
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}