﻿using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class WordDocument
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public byte[] FileContent { get; set; }
        public int? MeetingId { get; set; }
    }
}