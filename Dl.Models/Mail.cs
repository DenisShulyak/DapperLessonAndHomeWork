using System;

namespace Dl.Models
{
    public class Mail :Entity
    {
        public string Thems { get; set; }

        public string Text { get; set; }

        public Guid RecieverId { get; set; }
        public Guid SenderId { get; set; }

        public Sender Sender { get; set; }
        public Reciever Reciever { get; set; }

    }
}