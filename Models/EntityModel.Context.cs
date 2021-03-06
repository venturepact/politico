﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Politico.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class PoliticoEntities : DbContext
    {
        public PoliticoEntities()
            : base("name=PoliticoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Party> Parties { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Constituency> Constituencies { get; set; }
        public DbSet<MP> MPs { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Result> Results { get; set; }
    
        public virtual ObjectResult<FindMPOfConstituency_Result> FindMPOfConstituency(string constituency)
        {
            var constituencyParameter = constituency != null ?
                new ObjectParameter("constituency", constituency) :
                new ObjectParameter("constituency", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindMPOfConstituency_Result>("FindMPOfConstituency", constituencyParameter);
        }
    
        public virtual int SaveMember(string loginID, string firstName, string middleName, string lastName, string profileImage)
        {
            var loginIDParameter = loginID != null ?
                new ObjectParameter("loginID", loginID) :
                new ObjectParameter("loginID", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("middleName", middleName) :
                new ObjectParameter("middleName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var profileImageParameter = profileImage != null ?
                new ObjectParameter("profileImage", profileImage) :
                new ObjectParameter("profileImage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveMember", loginIDParameter, firstNameParameter, middleNameParameter, lastNameParameter, profileImageParameter);
        }
    
        public virtual int SaveComment(Nullable<decimal> rating, string comment, Nullable<int> sectorID, string loginID, Nullable<long> mpID)
        {
            var ratingParameter = rating.HasValue ?
                new ObjectParameter("rating", rating) :
                new ObjectParameter("rating", typeof(decimal));
    
            var commentParameter = comment != null ?
                new ObjectParameter("comment", comment) :
                new ObjectParameter("comment", typeof(string));
    
            var sectorIDParameter = sectorID.HasValue ?
                new ObjectParameter("sectorID", sectorID) :
                new ObjectParameter("sectorID", typeof(int));
    
            var loginIDParameter = loginID != null ?
                new ObjectParameter("loginID", loginID) :
                new ObjectParameter("loginID", typeof(string));
    
            var mpIDParameter = mpID.HasValue ?
                new ObjectParameter("mpID", mpID) :
                new ObjectParameter("mpID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveComment", ratingParameter, commentParameter, sectorIDParameter, loginIDParameter, mpIDParameter);
        }
    
        public virtual ObjectResult<FindMPRating_Result> FindMPRating(Nullable<long> mPID, string loginID)
        {
            var mPIDParameter = mPID.HasValue ?
                new ObjectParameter("MPID", mPID) :
                new ObjectParameter("MPID", typeof(long));
    
            var loginIDParameter = loginID != null ?
                new ObjectParameter("loginID", loginID) :
                new ObjectParameter("loginID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindMPRating_Result>("FindMPRating", mPIDParameter, loginIDParameter);
        }
    
        public virtual ObjectResult<FindMPComment_Result> FindMPComment(Nullable<long> mPID)
        {
            var mPIDParameter = mPID.HasValue ?
                new ObjectParameter("MPID", mPID) :
                new ObjectParameter("MPID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindMPComment_Result>("FindMPComment", mPIDParameter);
        }
    
        public virtual ObjectResult<SelectQuestion_Result> SelectQuestion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectQuestion_Result>("SelectQuestion");
        }
    
        public virtual ObjectResult<SaveAnswer_Result> SaveAnswer(Nullable<int> questionID, Nullable<bool> isAgree, string loginID)
        {
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("questionID", questionID) :
                new ObjectParameter("questionID", typeof(int));
    
            var isAgreeParameter = isAgree.HasValue ?
                new ObjectParameter("isAgree", isAgree) :
                new ObjectParameter("isAgree", typeof(bool));
    
            var loginIDParameter = loginID != null ?
                new ObjectParameter("loginID", loginID) :
                new ObjectParameter("loginID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SaveAnswer_Result>("SaveAnswer", questionIDParameter, isAgreeParameter, loginIDParameter);
        }
    }
}
