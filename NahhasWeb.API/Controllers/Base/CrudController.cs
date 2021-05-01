using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NahhasWeb.Shared.Entities.Base;
using NahhasWeb.Shared.Filters.Interfaces;
using NahhasWeb.Shared.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NahhasWeb.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudController<T> : ControllerBase where T : EntityBase
    {
        private readonly IUnitOfWork<T> _uow;

        public CrudController(IUnitOfWork<T> uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            try
            {
                var entities = await _uow.Database.Get();

                if (entities == null)
                    return NotFound($"No any {typeof(T).Name} found!");

                return Ok(entities);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data!");
            }
        }

        [HttpGet("{filter}")]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get(IFilter<T> filter)
        {
            try
            {
                var entities = await _uow.Database.Get(filter);

                if (entities == null)
                    return NotFound($"Any {typeof(T).Name} with these attributes was not found!");

                return Ok(entities);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data!");
            }
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<ActionResult<T>> Get(Guid id)
        {
            try
            {
                var entity = await _uow.Database.Get(id);

                if (entity == null)
                    return NotFound($"{typeof(T).Name} with Id = {id} not found!");

                return Ok(entity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data!");
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post(T entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest($"The {typeof(T).Name} cannot null!");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var added = await _uow.Database.Add(entity);
                return await _uow.Save() >= 1 ? CreatedAtAction(nameof(Get), new { id = added.Id }, added.Id) : BadRequest(entity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data!");
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<T>> Put(T entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest($"The {typeof(T).Name} cannot null!");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updated = await _uow.Database.Update(entity);
                return await _uow.Save() >= 1 ? Ok(updated) : BadRequest(entity);
            }
            catch
            {
                if (!await IsExist(entity.Id))
                    return NotFound($"{typeof(T).Name} with Id = {entity.Id} not found!");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data!");
            }
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult<T>> Delete(Guid id)
        {
            try
            {
                var deleted = await _uow.Database.Delete(id);
                return await _uow.Save() >= 1 ? Ok(deleted) : BadRequest(deleted);
            }
            catch
            {
                if (!await IsExist(id))
                    return NotFound($"{typeof(T).Name} with Id = {id} not found!");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data!");
            }
        }

        private async Task<bool> IsExist(Guid id) => (await _uow.Database.Get()).Any(e => e.Id == id);
    }
}