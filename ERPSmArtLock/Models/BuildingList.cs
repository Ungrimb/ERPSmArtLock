using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class BuildingList
    {
        public int BuildingId { get; set; }
        public int OwnerId { get; set; }
        public string BuildingName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string BuildingAddress { get; set; }
        public string BuildingImage { get; set; }
        public string Description { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int Rooms { get; set; }
        public int AllowedUsers { get; set; }
        public string VerificationCode { get; set; }
        public int Status { get; set; }
    }
}
