﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.BusinessLogic.DTO
{
    public class ArticleEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}