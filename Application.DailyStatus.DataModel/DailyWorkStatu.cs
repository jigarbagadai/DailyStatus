//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.DailyStatus.DataAccessEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DailyWorkStatu
    {
        public int Id { get; set; }
        public int UserDateWiseId { get; set; }
        public string CaseNo { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string OtherStatus { get; set; }
        public string Comments { get; set; }
    
        public virtual UserDateWiseStatu UserDateWiseStatu { get; set; }
    }
}
