﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rezervq
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class rezervEntities : DbContext
    {
        private static rezervEntities _context;
        public rezervEntities()
            : base("name=rezervEntities")
        {
        }


        public static rezervEntities GetContext()
        {
            if (_context == null)
                _context = new rezervEntities();

            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cabinet> cabinet { get; set; }
        public virtual DbSet<fio> fio { get; set; }
        public virtual DbSet<spec> spec { get; set; }
    }
}
