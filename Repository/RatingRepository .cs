using Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        ShopApiContext _context;


        public RatingRepository(ShopApiContext shopApiContext)
        {
            _context = shopApiContext;
        }

        public async Task AddOrder(Rating raiting)
        {

            _context.Ratings.AddAsync(raiting);
            await _context.SaveChangesAsync();
            return;

        }
    }


}
