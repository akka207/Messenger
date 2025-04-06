﻿using System.ComponentModel.DataAnnotations;

namespace Messenger.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        public DateTime? LastOnline { get; set; }
        public string? PicturePath { get; set; }
    }
}
