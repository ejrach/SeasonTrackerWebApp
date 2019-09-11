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

        //Apply data annotation for the HTML markup for the "MemberName" property.
        //This can be changed to whatever you want displayed wherever you you use MemberName
        [Required]
        [StringLength(255)]
        [Display(Name = "Member Name")]
        public string MemberName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public AccountType AccountType { get; set; }

        [Display(Name = "Account Type")]
        public byte AccountTypeId { get; set; }

        //Each member can have a collection of TvShows they are watching
        public virtual ICollection<TvShow> TvShows { get; set; }

        //Each member can have a collection of WatchLists to display
        public virtual ICollection<WatchList> WatchLists { get; set; }

    }
}