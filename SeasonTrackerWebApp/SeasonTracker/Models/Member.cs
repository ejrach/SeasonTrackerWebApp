using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeasonTracker.Models
{
    public class Member
    {
        //Tip: after adding a property it's a good idea to create migrations in small increments:
        //After adding a property for example, "IsSubscribedToNewsletter, go to PM
        //  PM > add-migration AddIsSubscribedToCustomer
        //  PM > Update-Database
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string MemberName { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public AccountType AccountType { get; set; }
        public byte AccountTypeId { get; set; }
        public WatchList WatchList { get; set; }
    }
}