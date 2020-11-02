using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSmArtLock.Data.Repositories
{
    public class LockListRepository : DataRepository<LockList, ERPContext>
    {

        private readonly ERPContext _context;
        public LockListRepository(ERPContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<LockList>> GetAll()
        {
            return await _context.LockList
                .ToListAsync();
        }

        public override async Task<LockList> Get(int id)
        {
            return await _context.LockList
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<LockList> AddLockList(LockList lockList)
        {

            var newLockList = new LockList();

            newLockList.BuildingId = lockList.BuildingId;
            newLockList.RoomName = lockList.RoomName;
            newLockList.OwnerId = lockList.OwnerId;
            newLockList.CheckIn = lockList.CheckIn;
            newLockList.CheckOut = lockList.CheckOut;
            newLockList.IsLimited = lockList.IsLimited;
            newLockList.Qrcode = lockList.Qrcode;
            newLockList.CheckDoubletick = lockList.CheckDoubletick;
            newLockList.Doubletick = lockList.Doubletick;
            newLockList.AllowedUsers = lockList.AllowedUsers;
            newLockList.IsFavorite = lockList.IsFavorite;

            _context.Set<LockList>().Add(newLockList);
            await _context.SaveChangesAsync();

            return newLockList;
        }
        public async Task<ActionResult<LockList>> DeleteLockList([FromBody] int id)
        {
            var lockList = await _context.LockList.FindAsync(id);

            _context.LockList.Remove(lockList);
            await _context.SaveChangesAsync();

            return lockList;
        }

    }
}
