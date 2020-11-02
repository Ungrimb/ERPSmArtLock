using Microsoft.AspNetCore.Mvc;
using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Cors;
using ERPSmArtLock.Data.Repositories;

namespace ERPSmArtLock.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LockListsController : GenericController<LockList, LockListRepository>
    {
        private readonly LockListRepository _repository;

        public LockListsController(LockListRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
