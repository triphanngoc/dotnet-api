﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApi.Core.Models.User
{
    public class UserUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
