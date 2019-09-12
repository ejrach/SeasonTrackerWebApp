using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeasonTracker.Models;

namespace SeasonTracker.ViewModels
{
    //In this view model, we are encapsulating all of the data required for 
    //displaying data within the Member Form View.
    //This ViewModel needs to exist in order to pass a view object within MembersController
    public class MemberFormViewModel
    {
        //List of account types
        public IEnumerable<AccountType> AccountTypes { get; set; }

        //Let's reuse the Member model
        public Member Member { get; set; }

        //A derived property. Used for Viewbag title
        public string Title
        {
            get
            {
                if (Member != null && Member.Id != 0)
                    return "Edit Member";
                return "New Member";
            }
        }
    }
}