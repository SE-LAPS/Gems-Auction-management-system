
using backend.Data;
using backend.Dto.Store;
using backend.Extensions;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("backend/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStoreRepository _storeRepo;
        private readonly UserManager<User> _userManager;
        public StoreController(ApplicationDBContext context, UserManager<User> userManager, IStoreRepository storeRepo) 
        {
            _context = context;
            _userManager = userManager;
            _storeRepo = storeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stores = await _storeRepo.GetAllAsync();
            var storeDto = stores.Select(s => s.ToStoreDto());

            return Ok(storeDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var store = await _storeRepo.GetByIdAsync(id);

            if (store == null) 
            {
                return NotFound();
            }

            return Ok(store.ToStoreDto());
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser([FromRoute] string userId)
        {
            var store = await _storeRepo.GetByUserIdAsync(userId);

            if(store == null)
            {
                return NotFound();
            }

            return Ok(store.ToStoreDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateStoreDto storeDto)
        {
            var username = User.GetUsername();

            if (string.IsNullOrEmpty(username)) 
            {
                return BadRequest("Username cannot be null or empty");
            }

            var user = await _userManager.FindByNameAsync(username);

            if(user == null)
            {
                return NotFound("User not found");
            }

            var userId = user.Id;

            var storeModel = storeDto.ToStoreFromCreate(userId);
            await _storeRepo.CreateAsync(storeModel);
            return CreatedAtAction(nameof(GetById), new { id = storeModel.Id }, storeModel.ToStoreDto());
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var storeModel = await _storeRepo.DeleteAsync(id);

            if(storeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStoreDto storeDto)
        {
            var storeModel = await _storeRepo.UpdateAsync(id, storeDto.ToStoreFromUpdate(id));

            if(storeModel == null)
            {
                return NotFound();
            }

            return Ok(storeModel.ToStoreDto());
        }
    }
}
