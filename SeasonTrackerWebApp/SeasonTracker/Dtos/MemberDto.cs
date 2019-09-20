using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeasonTracker.Dtos
{
    //DTO is Data Transfer Object.
    //Why are we using Dto's?
    //The Member API returns member objects. The member object in the API is part of the domain model of the application.
    //It's considered implementation detail. If the member object changes it breaks the interface. 
    //So Dto's are one way to get around that, in addition to using Automapper to map the Dto member object (seen here), to the 
    //Member domain model.
    public class MemberDto
    {
        //There is no need to include all of the other properties in the domain model
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string MemberName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte AccountTypeId { get; set; }

        public AccountTypeDto AccountType { get; set; }


        ///*
        // * 
        // * Model References
        // * 
        // */
        //public AccountType AccountType { get; set; }

        ////Each member can have a collection of TvShows they are watching
        //public virtual ICollection<TvShowDto> TvShowsDto { get; set; }

        ////Each member can have a collection of WatchLists to display
        //public virtual ICollection<WatchListDto> WatchListsDto { get; set; }
    }
}