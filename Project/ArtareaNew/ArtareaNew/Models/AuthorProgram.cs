//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtareaNew.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthorProgram
    {
        public int Id { get; set; }
        public int Authorid { get; set; }
        public int Programid { get; set; }
        public System.DateTime Createdate { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Program Program { get; set; }
    }
}
