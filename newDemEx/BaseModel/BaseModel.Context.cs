﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace newDemEx.BaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sdvgEntities : DbContext
    {
        public sdvgEntities()
            : base("name=sdvgEntities")
        {
        }

        private sdvgEntities _context;

        public sdvgEntities GetContext()
        {
            if (_context == null)
                _context = new sdvgEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialInProduct> MaterialInProduct { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pack> Pack { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInOrder> ProductInOrder { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
    }
}
