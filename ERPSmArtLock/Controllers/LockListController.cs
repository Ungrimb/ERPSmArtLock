using Microsoft.AspNetCore.Mvc;
using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Cors;
using ERPSmArtLock.Data.Repositories;
using System.Threading.Tasks;

namespace ERPSmArtLock.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LockListController : GenericController<LockList, LockListRepository>
    {
        private readonly LockListRepository _repository;

        public LockListController(LockListRepository repository) : base(repository)
        {
            _repository = repository;
        }

        // POST: api/LockList
        [HttpPost("lockList")]
        public async Task<ActionResult<LockList>> PostLockList(LockList lockList)
        {
            var newLockList = new LockList
            {
                Id = lockList.BuildingId,
                RoomName = lockList.RoomName,
                OwnerId = lockList.OwnerId,
                CheckIn = lockList.CheckIn,
                CheckOut = lockList.CheckOut,
                IsLimited = lockList.IsLimited,
                Qrcode = lockList.Qrcode,
                CheckDoubletick = lockList.CheckDoubletick,
                Doubletick = lockList.Doubletick,
                AllowedUsers = lockList.AllowedUsers,
                IsFavorite = lockList.IsFavorite
        };

            return await _repository.Add(newLockList);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<LockList>> EditLockList(LockList lockList)
        {

            var lockListEdited = await _repository.Get(lockList.Id);

            lockListEdited.BuildingId = lockList.BuildingId;
            lockListEdited.RoomName = lockList.RoomName;
            lockListEdited.OwnerId = lockList.OwnerId;
            lockListEdited.CheckIn = lockList.CheckIn;
            lockListEdited.CheckOut = lockList.CheckOut;
            lockListEdited.IsLimited = lockList.IsLimited;
            lockListEdited.Qrcode = lockList.Qrcode;
            lockListEdited.CheckDoubletick = lockList.CheckDoubletick;
            lockListEdited.Doubletick = lockList.Doubletick;
            lockListEdited.AllowedUsers = lockList.AllowedUsers;
            lockListEdited.IsFavorite = lockList.IsFavorite;

            return await _repository.Update(lockListEdited);

        }
        // DELETE: api/LockList/5
        [HttpDelete("{id}")]
        public Task<ActionResult<LockList>> DeleteLockList(int id)
        {
            return _repository.DeleteLockList(id);
        }
    }
}
