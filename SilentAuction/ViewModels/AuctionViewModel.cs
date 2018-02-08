using SilentAuction.Models;
using System.Collections.Generic;

namespace SilentAuction.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public IList<Category> Categories { get; set; }

        public PaginatedList<Listing> Listings { get; set; }

        public string SearchQuery { get; set; }

        public string AuctionName { get; set; }

        public string AuctionEndDate { get; set; }

        public int? PageSize { get; set; }
    }
}


