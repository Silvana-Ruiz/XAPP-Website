﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xapp.Domain.DTOs;
using Xapp.Domain.Enums;

namespace Xapp.Domain.Entities
{
    public class Comment : Entity
    {

        public string Content { get; set; }
        public int Likes { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; } 
        public int UserId { get; set; }
        public virtual User User { get; set; }


        
    }
}