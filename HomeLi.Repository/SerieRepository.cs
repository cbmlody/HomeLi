using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.Models;

namespace HomeLi.Repository
{
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        public SerieRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }
    }
}