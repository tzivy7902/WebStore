using Entities;
using Entytess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class RatingRepository:IRatingRepository
    {
      
      

            private readonly StoreDatabaseContext _dbContext;
            public RatingRepository(StoreDatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Rating> AddRating(Rating r)
            {

        await    _dbContext.AddAsync(r);
         await   _dbContext.SaveChangesAsync();
            return r;

        }



        }

    }

