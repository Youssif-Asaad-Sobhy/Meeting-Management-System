﻿using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //Attributes
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string Password { get; set; }

        //Relations
        public List<MemberCommittee> MemberCommittees { get; set; }
        public List<MemberAnswers> MemberAnswers { get; set; } 

    }
}
