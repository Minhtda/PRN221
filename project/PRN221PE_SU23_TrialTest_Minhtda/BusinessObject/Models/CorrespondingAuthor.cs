using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject.Models
{
    public partial class CorrespondingAuthor
    {
        [Required]
        public string AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public DateTime AuthorBirthday { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public int? InstitutionId { get; set; }

        public virtual InstitutionInformation Institution { get; set; }
    }
}
