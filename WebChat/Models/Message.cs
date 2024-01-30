namespace WebChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsReceived { get; set; }
        public DateTime CreatedAt { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public int SenderUserId { get; set; }
    }
}
