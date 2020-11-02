using System;
using System.Collections.Generic;

namespace ERPSmArtLock.Models
{
    public partial class AllowedInfo : IEntity
    {
        public int Id { get; set; }
        public int AllowedUserId { get; set; }
        public int OwnerId { get; set; }
        public int BuildingId { get; set; }
        public int LockId { get; set; }
        public int AllowedMethod { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Reason { get; set; }
        public string ChatRoomId { get; set; }
        public string UnReadMsgCnt { get; set; }
        public string AllowedUserEmail { get; set; }
        public int AllowedStatus { get; set; }
        public string DayWise { get; set; }
    }
}
