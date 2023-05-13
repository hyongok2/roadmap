﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.MVVM.Models
{
    public class MessageModel
    {
        public string Username { get; set; } = string.Empty;
        public string UsernameColor { get; set; } = string.Empty;
        public string ImageSource { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Time { get; set; }  
        public bool IsNativeOrigin { get; set; }    
        public bool? FirstMessage { get; set; }
    }
}
