﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace solveMe
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }   
        public string password { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isAdmin { get; set; }
        public bool isExpert { get; set; }

    }
}