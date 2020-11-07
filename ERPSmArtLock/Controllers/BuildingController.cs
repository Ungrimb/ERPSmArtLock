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
    public class BuildingController : GenericController<Building, BuildingRepository>
    {
        private readonly BuildingRepository _repository;

        public BuildingController(BuildingRepository repository) : base(repository)
        {
            _repository = repository;
        }

        // POST: api/Building
        [HttpPost("building")]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
        var newBuilding = new Building
            {
                Id = building.Id,
                OwnerId = building.OwnerId,
                BuildingName = building.BuildingName,
                OwnerName = building.OwnerName,
                OwnerEmail = building.OwnerEmail,
                BuildingAddress = building.BuildingAddress,
                BuildingImage = building.BuildingImage,
                Description = building.Description,
                Lat = building.Lat,
                Lng = building.Lng,
                Rooms = building.Rooms,
                AllowedUsers = building.AllowedUsers,
                VerificationCode = building.VerificationCode,
                Status = building.Status
        };

            return await _repository.Add(newBuilding);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Building>> EditBuilding(Building building)
        {

            var buildingEdited = await _repository.Get(building.Id);

            buildingEdited.Id = building.Id;
            buildingEdited.OwnerId = building.OwnerId;
            buildingEdited.BuildingName = building.BuildingName;
            buildingEdited.OwnerName = building.OwnerName;
            buildingEdited.OwnerEmail = building.OwnerEmail;
            buildingEdited.BuildingAddress = building.BuildingAddress;
            buildingEdited.BuildingImage = building.BuildingImage;
            buildingEdited.Description = building.Description;
            buildingEdited.Lat = building.Lat;
            buildingEdited.Lng = building.Lng;
            buildingEdited.Rooms = building.Rooms;
            buildingEdited.AllowedUsers = building.AllowedUsers;
            buildingEdited.VerificationCode = building.VerificationCode;
            buildingEdited.Status = building.Status;

            return await _repository.Update(buildingEdited);

        }
        // DELETE: api/Building/5
        [HttpDelete("{id}")]
        public Task<ActionResult<Building>> DeleteBuilding(int id)
        {
            return _repository.DeleteBuilding(id);
        }
    }
}
