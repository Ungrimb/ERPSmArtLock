using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class Documents : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Signature { get; set; }
    }
}
