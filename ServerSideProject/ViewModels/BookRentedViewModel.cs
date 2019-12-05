using System.Collections.Generic;
using ServerSideProject.Models;

namespace ServerSideProject.ViewModels
{
    //This file provides information about which users have rented which book

    public class BookRentedViewModel
    {
        public Book Book { get; set; }
        public List<Author> Users { get; set; }
    }
}