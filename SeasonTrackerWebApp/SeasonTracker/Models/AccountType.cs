using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeasonTracker.Models
{
    public class AccountType
    {
        //Acount types models will be:
        // 1) Free - access to minimum features of the web app - name this account type "Free" Plan
        // 2) Paid (monthly) - access to additional features of the web app - name this account type "Enthusiast" Plan
        // 3) Paid (yearly) - access to the same additional features as the monthly, but at a discount - "Devotee" Plan
        // 4) Paid (one time) - master access to all features of the web app - "Addict"
        public byte Id { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}