using System;
using Core.ViewrRequests;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    public class CabinStoreController : ControllerBase
    {
        private readonly ICabinStoreService _cabinStoreService;

        public CabinStoreController(ICabinStoreService cabinStoreService)
        {
            _cabinStoreService = cabinStoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _cabinStoreService.ListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStore(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            try
            {
                var response = await _cabinStoreService.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStoreModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var response = await _cabinStoreService.Add(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateStoreModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var response = await _cabinStoreService.Update(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var response = await _cabinStoreService.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{storeId}/products")]
        public async Task<IActionResult> GetProductsByStoreId(Guid storeId)
        {
            try
            {
                var response = await _cabinStoreService.GetProductsByStoreId(storeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{storeId}/categories")]
        public async Task<IActionResult> GetCategoriesByStoreId(Guid storeId)
        {
            try
            {
                var response = await _cabinStoreService.GetCategoriesByStoreId(storeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

