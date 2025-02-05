using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Account;
using api.Dtos.Stock;
using api.Extenstions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers{

    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase{

        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepo, IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio(){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetBySymbolAsync(symbol);  
            if(stock == null) return BadRequest("Stock does not exist");
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
            if(userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower())) return BadRequest("Cannot add same stock to portfolio");
            var portfolioModel = new Portfolio{
                StockId = stock.Id,
                AppUserId = appUser.Id
            };

            await _portfolioRepository.CreateAsync(portfolioModel);
            if(portfolioModel == null) return StatusCode(500, "Could not create");
            else{
                return Created();
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
            var filteredStock = userPortfolio.Where(s => s.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if(filteredStock.Count() == 1) await _portfolioRepository.DeletePorfolio(appUser, symbol);
            else{
                return BadRequest("Stock is not in your portfolio");
            }
            return Ok();
        }

    }

}