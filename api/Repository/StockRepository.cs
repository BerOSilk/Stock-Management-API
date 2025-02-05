using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using api.Helpers.Factories;
using Microsoft.EntityFrameworkCore;
using api.Helpers;

namespace api.Repository{

    public class StockRepository : IStockRepository
    {

        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await GetByIdAsync(id);
            if(stockModel == null) return null;
            _context.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).AsQueryable();
            var Specifications = FilteringFactory.GetStockFilteringOptions(query);
            foreach(var specfication in Specifications){
                stocks = specfication.ApplyFiltering(stocks);
            }
            if(!string.IsNullOrEmpty(query.SortBy)){
                var Option = SortingFactory.GetSortingOption(query.SortBy);
                if(Option != null) stocks = Option.ApplySorting(stocks, query.Descending);
            }
            int skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }


        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public Task<bool> StockExistsAsync(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var stockModel = await GetByIdAsync(id);
            
            if(stockModel == null) return null;

            stockModel.Symbol = stockDto.Symbol;
            stockModel.CompanyName = stockDto.CompanyName;
            stockModel.Purchase = stockDto.Purchase;
            stockModel.LastDiv = stockDto.LastDiv;
            stockModel.Industry = stockDto.Industry;
            stockModel.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return stockModel;

        }
    }

}