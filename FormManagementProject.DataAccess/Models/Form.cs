//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormManagementProject.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Form
    {
        public int Id { get; set; }
        
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public Nullable<int> createdBy { get; set; }
        public string fields { get; set; }
        
        public string formUserName { get; set; }
        
        public string formUserSurname { get; set; }
        public Nullable<int> formUserAge { get; set; }
    }
}
