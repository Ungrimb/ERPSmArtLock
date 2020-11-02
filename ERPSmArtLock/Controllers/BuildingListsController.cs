using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Cors;
using ERPSmArtLock.Data.Repositories;

namespace ERPSmArtLock.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingListsController : GenericController<BuildingList, BuildingRepository>
    {
        private readonly BuildingRepository _repository;

        public BuildingListsController(BuildingRepository repository) : base(repository)
        {
            _repository = repository;
        }

        // POST: api/BuildingLists
        [HttpPost("buildingList")]
        public async Task<ActionResult<BuildingList>> PostBuildingList(BuildingList buildingList)
        {
        var newBuildingList = new BuildingList
            {
                Id = buildingList.Id,
                OwnerId = buildingList.OwnerId,
                BuildingName = buildingList.BuildingName,
                OwnerName = buildingList.OwnerName,
                OwnerEmail = buildingList.OwnerEmail,
                BuildingAddress = buildingList.BuildingAddress,
                BuildingImage = buildingList.BuildingImage,
                Description = buildingList.Description,
                Lat = buildingList.Lat,
                Lng = buildingList.Lng,
                Rooms = buildingList.Rooms,
                AllowedUsers = buildingList.AllowedUsers,
                VerificationCode = buildingList.VerificationCode,
                Status = buildingList.Status
        };

            return await _repository.Add(newBuildingList);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<BuildingList>> EditBuildingList(BuildingList buildingList)
        {

            var buildingListEdited = await _repository.Get(buildingList.Id);

            buildingListEdited.Id = buildingList.Id;
            buildingListEdited.OwnerId = buildingList.OwnerId;
            buildingListEdited.BuildingName = buildingList.BuildingName;
            buildingListEdited.OwnerName = buildingList.OwnerName;
            buildingListEdited.OwnerEmail = buildingList.OwnerEmail;
            buildingListEdited.BuildingAddress = buildingList.BuildingAddress;
            buildingListEdited.BuildingImage = buildingList.BuildingImage;
            buildingListEdited.Description = buildingList.Description;
            buildingListEdited.Lat = buildingList.Lat;
            buildingListEdited.Lng = buildingList.Lng;
            buildingListEdited.Rooms = buildingList.Rooms;
            buildingListEdited.AllowedUsers = buildingList.AllowedUsers;
            buildingListEdited.VerificationCode = buildingList.VerificationCode;
            buildingListEdited.Status = buildingList.Status;

            return await _repository.Update(buildingListEdited);

        }
        // DELETE: api/BuildingLists/5
        [HttpDelete("{id}")]
        public Task<ActionResult<BuildingList>> DeleteBuildingList(int id)
        {
            return _repository.DeleteBuildingList(id);
        }
    }
}
