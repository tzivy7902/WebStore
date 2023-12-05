using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IRatingRepository
    {
        Task<Rating> AddRating(Rating r);
    }
}
