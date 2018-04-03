using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtareaNew.Models
{
    public class AddAuthor
    {
        public HttpFileCollectionBase Photo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string Profession { get; set; }
    }
}