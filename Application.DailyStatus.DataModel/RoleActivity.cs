//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.DailyStatus.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleActivity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ActivityId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Role Role { get; set; }
    }
}