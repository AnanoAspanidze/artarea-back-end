﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArtareaEntities : DbContext
    {
        public ArtareaEntities()
            : base("name=ArtareaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorProgram> AuthorPrograms { get; set; }
        public virtual DbSet<AuthorSery> AuthorSeries { get; set; }
        public virtual DbSet<AuthorTranslate> AuthorTranslates { get; set; }
        public virtual DbSet<Blogpost> Blogposts { get; set; }
        public virtual DbSet<BlogpostTranslate> BlogpostTranslates { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProgram> CategoryPrograms { get; set; }
        public virtual DbSet<CategoryTranslate> CategoryTranslates { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTranslate> EventTranslates { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Filetype> Filetypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<ProgramTranslate> ProgramTranslates { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<SeriesTranslate> SeriesTranslates { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
