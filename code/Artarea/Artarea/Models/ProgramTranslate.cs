//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Artarea.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProgramTranslate
    {
        public int Id { get; set; }
        public int Programid { get; set; }
        public string LangCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Datetime { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Program Program { get; set; }
    }
}
