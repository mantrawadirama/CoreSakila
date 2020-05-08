using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public CategoryController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _repository.Category.GetAllCategories();
                _logger.LogInfo($"Returned all owners from database.");

                var categoryResult = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return Ok(categoryResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByCategoryId(int id)
        {
            try
            {
                var categories = await _repository.Category.GetProductsByCategoryId(id);
                _logger.LogInfo($"Returned all owners from database.");

                var categoryResult = _mapper.Map<CategoryDto>(categories);
                return Ok(categoryResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}