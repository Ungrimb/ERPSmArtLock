using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class EventList : IEntity
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int LockId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }
}
