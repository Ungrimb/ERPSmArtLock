using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class Settings : IEntity
    {
        public int Id { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public string Aboutus { get; set; }
        public string SupportEmail { get; set; }
    }
}
