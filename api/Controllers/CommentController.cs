using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Extenstions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers{

    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase{
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentRepository commentRepo,
        IStockRepository stockRepo,
        UserManager<AppUser> userManager)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(){

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepo.GetAllAsync();
            var commentDto = comment.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        } 
        
        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null) return NotFound();
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{StockId:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int StockId, CreateCommentDto commentDto){
    
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(! await _stockRepo.StockExistsAsync(StockId)){
                return BadRequest("Stock does not exist");
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var comment = commentDto.ToComment(StockId);
            comment.AppUserId = appUser.Id;
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new {id = comment.Id}, comment.ToCommentDto());
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCommentDto commentDto){
            
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, commentDto);

            if(comment == null) return NotFound("Comment not found");
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){

            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            var comment = await _commentRepo.DeleteAsync(id);
            if(comment == null) return NotFound("Comment not found");
            return Ok(comment.ToCommentDto());
        }

    }

}