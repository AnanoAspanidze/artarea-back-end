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
    
    public partial class EventTranslate
    {
        public int Id { get; set; }
        public int Eventid { get; set; }
        public string LangCode { get; set; }
        public string Name { get; set; }
        public System.DateTime Createdate { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Language Language { get; set; }
    }
}
