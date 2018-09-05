namespace HomeLi.Contracts
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }
        ISerieRepository Serie { get; }
    }
}