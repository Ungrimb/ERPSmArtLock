using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class LockList : IEntity
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int BuildingId { get; set; }
        public string RoomName { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public int IsLimited { get; set; }
        public string Qrcode { get; set; }
        public string CheckDoubletick { get; set; }
        public string Doubletick { get; set; }
        public int AllowedUsers { get; set; }
        public int IsFavorite { get; set; }
    }
}
