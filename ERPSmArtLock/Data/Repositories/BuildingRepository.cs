using ERPSmArtLock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSmArtLock.Data.Repositories
{
    public class BuildingRepository : DataRepository<BuildingList, ERPContext>
    {

        private readonly ERPContext _context;
        public BuildingRepository(ERPContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<BuildingList>> GetAll()
        {
            return await _context.BuildingList
                .ToListAsync();
        }

        public override async Task<BuildingList> Get(int id)
        {
            var buildingList = await _context.BuildingList
                .SingleOrDefaultAsync(p => p.Id == id);

            return buildingList;
        }

        public async Task<BuildingList> AddProduct(BuildingList buildingList)
        {

            var newBuildingList = new BuildingList();

            newBuildingList.BuildingName = buildingList.BuildingName;
            newBuildingList.Description = buildingList.Description;
            newBuildingList.OwnerName = buildingList.OwnerName;
            newBuildingList.OwnerId = buildingList.OwnerId;
            newBuildingList.OwnerEmail = buildingList.OwnerEmail;
            newBuildingList.BuildingAddress = buildingList.BuildingAddress;
            newBuildingList.BuildingImage = buildingList.BuildingImage;
            newBuildingList.Lat = buildingList.Lat;
            newBuildingList.Lng = buildingList.Lng;
            newBuildingList.OwnerEmail = buildingList.OwnerEmail;
            newBuildingList.Rooms = buildingList.Rooms;
            newBuildingList.AllowedUsers = buildingList.AllowedUsers;
            newBuildingList.VerificationCode = buildingList.VerificationCode;
            newBuildingList.Status = buildingList.Status;
            _context.Set<BuildingList>().Add(newBuildingList);
            await _context.SaveChangesAsync();

            return newBuildingList;
        }

    }
}
