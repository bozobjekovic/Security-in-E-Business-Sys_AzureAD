﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMailService.Helpers
{
    public class ComposeEmail
    {
        public string Receivers { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}