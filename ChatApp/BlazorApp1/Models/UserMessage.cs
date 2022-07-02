namespace BlazorApp1.Models
{
    public class UserMessage
    {
        public string UserName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool CurrentUser { get; set; }
        public DateTime DateSent { get; set; }
    }
}