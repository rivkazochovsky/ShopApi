using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RatingService : IRatingService
    {
        IRatingRepository repository;
        public RatingService(IRatingRepository _repositoryraiting)
        {
            repository = _repositoryraiting;
        }
        public async Task Addrating(Rating rating)
        {
            await repository.AddOrder(rating);
        }


    }



}
