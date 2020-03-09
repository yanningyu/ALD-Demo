using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALDQuoteService.Services
{
    public class Message : IMessage
    {
        public string Id { get; set; }

        public string Status { get;  set; }
    }
}