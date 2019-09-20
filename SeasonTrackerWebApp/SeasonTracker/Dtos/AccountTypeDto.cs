using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeasonTracker.Dtos
{
    public class AccountTypeDto
    {
        //There is no need to include all of the other properties in the domain model
        public byte Id { get; set; }

        public string Name { get; set; }
    }
}