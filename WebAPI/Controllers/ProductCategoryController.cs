using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Services.Interfaces;
using WebAPI.Extensions;
using Core.ViewrRequests;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryService _productCategorySerive;

        public ProductCategoryController(IProductCategoryService productCategorySerive)
        {
            _productCategorySerive = productCategorySerive;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _productCategorySerive.ListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            try
            {
                var response = await _productCategorySerive.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("{id}/items")]
        //public async Task<IActionResult> GetItemsByCategory(Guid id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState.GetErrorMessages());

        //    try
        //    {
        //        var response = await _productCategorySerive.GetItemsByCategory(id);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCategoryModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var response = await _productCategorySerive.Add(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateProductCategoryModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var response = await _productCategorySerive.Update(id, request);
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
                var response = await _productCategorySerive.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

