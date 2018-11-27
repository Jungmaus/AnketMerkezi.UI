using AnketMerkezi.Data.ORM.Entities;
using AnketMerkezi.Data.ORM.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnketMerkezi.Data.ORM.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyContent> SurveyContents { get; set; }
        public DbSet<SurveyVisitAnswer> SurveyVisitAnswers { get; set; }
        public DbSet<SurveyVisit> SurveyVisits { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<SupportRequestMessage> SupportRequestMessages { get; set; }
        public DbSet<SupportRequestMessageDocument> SupportRequestMessageDocuments { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserDetailMap());
            modelBuilder.ApplyConfiguration(new SurveyMap());
            modelBuilder.ApplyConfiguration(new SurveyContentMap());
            modelBuilder.ApplyConfiguration(new SurveyVisitAnswerMap());
            modelBuilder.ApplyConfiguration(new SurveyVisitMap());
            modelBuilder.ApplyConfiguration(new SupportRequestMap());
            modelBuilder.ApplyConfiguration(new SupportRequestMessageMap());
            modelBuilder.ApplyConfiguration(new SupportRequestMessageDocumentMap());
            modelBuilder.ApplyConfiguration(new UserOrderMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
        }
    }
}

