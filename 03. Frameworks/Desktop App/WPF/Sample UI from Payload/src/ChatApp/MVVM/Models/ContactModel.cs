using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.MVVM.Models
{
    public class ContactModel
    {
        public string Username { get; set; } = string.Empty;
        public string ImageSource { get; set; } = string.Empty;

        public ObservableCollection<MessageModel> Messages { get; set; }
        public string LastMessage => Messages.Last().Message;

    }
}
