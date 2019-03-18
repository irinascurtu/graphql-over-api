using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Service
{
    public class Feedback
    {
        public int Id { get; set; }
        public int Content { get; set; }
        public int Delivery { get; set; }
        public string Comments { get; set; }
        public int TalkId { get; set; }
    }
}
