using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class Locklist1 : IEntity
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int BuildingId { get; set; }
        public string LockImage { get; set; }
        public string RoomName { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public int IsLimited { get; set; }
        public string Qrcode { get; set; }
        public int AllowedUsers { get; set; }
        public int IsFavorite { get; set; }
    }
}
