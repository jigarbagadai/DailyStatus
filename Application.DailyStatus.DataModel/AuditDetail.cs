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
    
    public partial class AuditDetail
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public string OperationType { get; set; }
        public System.DateTime OperationDate { get; set; }
    }
}
