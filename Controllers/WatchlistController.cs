using Auth.Data;
using Auth.Interfaces;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Authorize]
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService watchlistService;
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGetCompaniesRequest companiesRequest;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly string watchlistUrl;

        public WatchlistController(IWatchlistService watchlistService, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, 
            IGetCompaniesRequest companiesRequest, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.watchlistService = watchlistService;
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.companiesRequest = companiesRequest;
            this.configuration = configuration;
            this.watchlistUrl = this.configuration["WatchlistUrl"];
        }

        public async Task<IActionResult> Index(string symbol)
        {
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                var companies = await this.watchlistService.GetCompanies(symbol);
                return this.View(companies);
            }

            return this.View("Index");
        }

        public async Task<IActionResult> AddToWatchlist(string symbol)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.HttpContext.User);
                var companies = this.dbContext.UserWatchlist.ToList();
                var companiesCapabilities = await this.watchlistService.GetCompanies(symbol);
                var companyOverview = await this.watchlistService.GetCompanyOverview(symbol);

                if (companiesCapabilities != null)
                {
                    var companyCapabilities = companiesCapabilities.BestMatches.FirstOrDefault();
                    var userWatchlist = new UserWatchlist
                    {
                        Symbol = symbol,
                        CompanyName = string.IsNullOrWhiteSpace(companyCapabilities.Name) ? string.Empty : companyCapabilities.Name,
                        CompanyRegion = string.IsNullOrWhiteSpace(companyCapabilities.Region) ? string.Empty : companyCapabilities.Region,
                        MarketOpen = string.IsNullOrWhiteSpace(companyCapabilities.MarketOpen) ? string.Empty : companyCapabilities.MarketOpen,
                        MarketClose = string.IsNullOrWhiteSpace(companyCapabilities.MarketClose) ? string.Empty : companyCapabilities.MarketClose,
                        StockPrice = companyOverview.PERatio * companyOverview.DividendPerShare,
                        User = user,
                    };

                    this.dbContext.UserWatchlist.Add(userWatchlist);
                    await this.dbContext.SaveChangesAsync();
                }

                return this.Redirect(this.watchlistUrl);
            }
            catch (DbUpdateException)
            {
                return this.RedirectToAction(nameof(AddToWatchlist), (symbol, saveChangesError: true));
            }

        }

        public async Task<IActionResult> Watchlist()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var companies = this.dbContext.UserWatchlist.ToList().Where(u => u.UserId == user.Id);
            var userCompanies = new List<UserWatchlistModel>();
            foreach (var company in companies)
            {
                userCompanies.Add(new UserWatchlistModel
                {
                    Symbol = company.Symbol,
                    CompanyName = company.CompanyName,
                    CompanyRegion = company.CompanyRegion,
                    MarketOpen = company.MarketOpen,
                    MarketClose = company.MarketClose,
                    StockPrice = company.StockPrice
                });
            }

            return this.View(userCompanies);
        }

        public async Task<IActionResult> Delete(string symbol)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.HttpContext.User);
                var companiesToRemove = this.dbContext.UserWatchlist.ToList().Where(u => u.Symbol.Equals(symbol) && u.UserId == user.Id);
                if (companiesToRemove != null)
                {
                    foreach (var company in companiesToRemove)
                    {
                        this.dbContext.Remove(company);
                    }

                    await this.dbContext.SaveChangesAsync();
                }

                return this.Redirect(this.watchlistUrl);
            }
            catch (DbUpdateException)
            {
                return this.RedirectToAction(nameof(Delete), new { symbol, saveChangesError = true });
            }

        }

        public IActionResult BackToSearch()
        {
            return this.View("Index");
        }
    }
}
