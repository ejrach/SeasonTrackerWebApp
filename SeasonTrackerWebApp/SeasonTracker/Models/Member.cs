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
        //This can be changed to whatever you want displayed wherever you you use MemberName.
        //Data Annotations. Override error message on input validation error.
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(255)]
        [Display(Name = "Member Name")]
        public string MemberName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Account Type")]
        public byte AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }

        /*
         * 
         * Model References
         * 
         */
        //public AccountType AccountType { get; set; }

        //Each member can have a collection of TvShows they are watching
        //TBD: need to get rid of virtual - could be slowing application down. See Mosh video on Glimpse
        //public virtual ICollection<TvShow> TvShows { get; set; }

        //Each member can have a collection of WatchLists to display
        //TBD: need to get rid of virtual - could be slowing application down. See Mosh video on Glimpse
        //public virtual ICollection<WatchList> WatchLists { get; set; }

    }
}