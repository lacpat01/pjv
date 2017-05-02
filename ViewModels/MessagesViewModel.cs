using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace groupePjvApp.ViewModels
{
    public class MessagesViewModel
    {
        public List<string> Messages { get; set; }

        public MessagesViewModel(List<string> messages)
        {
            this.Messages = messages;
        }
    }
}