using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceLayer.Mockups;

namespace ServiceLayer.Models
{
    public class UserDetails
    {
        
        private string userID;
        public UserDetails(string userID)
        {
     
           

        }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int UserID { get; set; }
    }
}