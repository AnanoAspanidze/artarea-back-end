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
    
    public partial class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Filetypeid { get; set; }
        public int Articleid { get; set; }
        public bool isMainfile { get; set; }
        public System.DateTime Createdate { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Filetype Filetype { get; set; }
    }
}
