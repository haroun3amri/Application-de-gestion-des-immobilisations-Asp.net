﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMMO.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IMMODEMOEntities : DbContext
    {
        public IMMODEMOEntities()
            : base("name=IMMODEMOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CODEBAR> CODEBARs { get; set; }
        public virtual DbSet<IMMO_AFFECTATION> IMMO_AFFECTATION { get; set; }
        public virtual DbSet<IMMO_AMORTISSEMENTANNUELLE> IMMO_AMORTISSEMENTANNUELLE { get; set; }
        public virtual DbSet<IMMO_AMORTISSEMENTPARTIELLE> IMMO_AMORTISSEMENTPARTIELLE { get; set; }
        public virtual DbSet<IMMO_ARTICLE> IMMO_ARTICLE { get; set; }
        public virtual DbSet<IMMO_ARTICLE_SESSION> IMMO_ARTICLE_SESSION { get; set; }
        public virtual DbSet<IMMO_ARTICLESUPPRIME> IMMO_ARTICLESUPPRIME { get; set; }
        public virtual DbSet<IMMO_BL> IMMO_BL { get; set; }
        public virtual DbSet<IMMO_CESSION> IMMO_CESSION { get; set; }
        public virtual DbSet<IMMO_COMPTE> IMMO_COMPTE { get; set; }
        public virtual DbSet<IMMO_DETAILBL> IMMO_DETAILBL { get; set; }
        public virtual DbSet<IMMO_DETAILFACTURE> IMMO_DETAILFACTURE { get; set; }
        public virtual DbSet<IMMO_EMPLACEMENT> IMMO_EMPLACEMENT { get; set; }
        public virtual DbSet<IMMO_EXERCICE> IMMO_EXERCICE { get; set; }
        public virtual DbSet<IMMO_FACTURE> IMMO_FACTURE { get; set; }
        public virtual DbSet<IMMO_FAMILLE> IMMO_FAMILLE { get; set; }
        public virtual DbSet<IMMO_FAMILLECOMPTABLE> IMMO_FAMILLECOMPTABLE { get; set; }
        public virtual DbSet<IMMO_FAMILLEM> IMMO_FAMILLEM { get; set; }
        public virtual DbSet<IMMO_FOURNISSEUR> IMMO_FOURNISSEUR { get; set; }
        public virtual DbSet<IMMO_HIST_AFFECTATION> IMMO_HIST_AFFECTATION { get; set; }
        public virtual DbSet<IMMO_HIST_AFFECTATION_ARTICLE> IMMO_HIST_AFFECTATION_ARTICLE { get; set; }
        public virtual DbSet<IMMO_INV_COMPTABILITE> IMMO_INV_COMPTABILITE { get; set; }
        public virtual DbSet<IMMO_INVENTAIRE> IMMO_INVENTAIRE { get; set; }
        public virtual DbSet<IMMO_INVETAIRE_ARTICLE> IMMO_INVETAIRE_ARTICLE { get; set; }
        public virtual DbSet<IMMO_LOCAL> IMMO_LOCAL { get; set; }
        public virtual DbSet<IMMO_SERVICE> IMMO_SERVICE { get; set; }
        public virtual DbSet<IMMO_TVA> IMMO_TVA { get; set; }
        public virtual DbSet<IMMO_TVARECUPERATION> IMMO_TVARECUPERATION { get; set; }
        public virtual DbSet<M_ARTMMB> M_ARTMMB { get; set; }
        public virtual DbSet<M_BUREAU> M_BUREAU { get; set; }
        public virtual DbSet<M_DSERV> M_DSERV { get; set; }
        public virtual DbSet<M_FAMMMB> M_FAMMMB { get; set; }
        public virtual DbSet<M_LOCAL> M_LOCAL { get; set; }
        public virtual DbSet<M_SFAM> M_SFAM { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<INV_PH> INV_PH { get; set; }
        public virtual DbSet<M_SFAM1> M_SFAM1 { get; set; }
        public virtual DbSet<IMMO_INV_LIVRE> IMMO_INV_LIVRE { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}