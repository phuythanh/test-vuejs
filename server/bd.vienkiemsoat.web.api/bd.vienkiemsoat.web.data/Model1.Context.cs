﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bd.vienkiemsoat.web.data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SOFTZ_UTDAUEntities1 : DbContext
    {
        public SOFTZ_UTDAUEntities1()
            : base("name=SOFTZ_UTDAUEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<RP_NHAPXUAT_PHIEU_Result> RP_NHAPXUAT_PHIEU(Nullable<int> uID, string lCT, string pDS_MAKHO, Nullable<System.DateTime> pTU, Nullable<System.DateTime> pDEN, string pDS_MADT)
        {
            var uIDParameter = uID.HasValue ?
                new ObjectParameter("UID", uID) :
                new ObjectParameter("UID", typeof(int));
    
            var lCTParameter = lCT != null ?
                new ObjectParameter("LCT", lCT) :
                new ObjectParameter("LCT", typeof(string));
    
            var pDS_MAKHOParameter = pDS_MAKHO != null ?
                new ObjectParameter("pDS_MAKHO", pDS_MAKHO) :
                new ObjectParameter("pDS_MAKHO", typeof(string));
    
            var pTUParameter = pTU.HasValue ?
                new ObjectParameter("pTU", pTU) :
                new ObjectParameter("pTU", typeof(System.DateTime));
    
            var pDENParameter = pDEN.HasValue ?
                new ObjectParameter("pDEN", pDEN) :
                new ObjectParameter("pDEN", typeof(System.DateTime));
    
            var pDS_MADTParameter = pDS_MADT != null ?
                new ObjectParameter("pDS_MADT", pDS_MADT) :
                new ObjectParameter("pDS_MADT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RP_NHAPXUAT_PHIEU_Result>("RP_NHAPXUAT_PHIEU", uIDParameter, lCTParameter, pDS_MAKHOParameter, pTUParameter, pDENParameter, pDS_MADTParameter);
        }
    }
}
