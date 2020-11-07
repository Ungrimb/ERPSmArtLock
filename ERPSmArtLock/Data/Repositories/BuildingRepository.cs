using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSmArtLock.Data.Repositories
{
    public class BuildingRepository : DataRepository<Building, ERPContext>
    {

        private readonly ERPContext _context;
        public BuildingRepository(ERPContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Building>> GetAll()
        {
            return await _context.Building
                .ToListAsync();
        }

        public override async Task<Building> Get(int id)
        {
            return await _context.Building
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Building> AddBuilding(Building building)
        {

            var newBuilding = new Building();

            newBuilding.BuildingName = building.BuildingName;
            newBuilding.Description = building.Description;
            newBuilding.OwnerName = building.OwnerName;
            newBuilding.OwnerId = building.OwnerId;
            newBuilding.OwnerEmail = building.OwnerEmail;
            newBuilding.BuildingAddress = building.BuildingAddress;
            newBuilding.BuildingImage = building.BuildingImage;
            newBuilding.Lat = building.Lat;
            newBuilding.Lng = building.Lng;
            newBuilding.OwnerEmail = building.OwnerEmail;
            newBuilding.Rooms = building.Rooms;
            newBuilding.AllowedUsers = building.AllowedUsers;
            newBuilding.VerificationCode = building.VerificationCode;
            newBuilding.Status = building.Status;
            _context.Set<Building>().Add(newBuilding);
            await _context.SaveChangesAsync();

            return newBuilding;
        }
        public async Task<ActionResult<Building>> DeleteBuilding([FromBody] int id)
        {
            var building = await _context.Building.FindAsync(id);

            _context.Building.Remove(building);
            await _context.SaveChangesAsync();

            return building;
        }

    }
}
