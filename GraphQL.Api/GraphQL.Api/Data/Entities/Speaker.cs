using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Entities
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        public string Website { get; set; }
        [Url]
        public string Facebook { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Url]
        public string LinkedIn { get; set; }
        [Url]
        public string Skype { get; set; }
        [Url]
        [Required]
        public string GitHub { get; set; }
        [Url]
        public string Twitter { get; set; }
        public string CompanyName { get; set; }
        [Url]
        public string CompanyWebsite { get; set; }
        [Required]
        public string Description { get; set; }
        public string PageSlug { get; set; }
    }
}
