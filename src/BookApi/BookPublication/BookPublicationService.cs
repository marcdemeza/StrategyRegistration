namespace BookApi.BookPublication;

public sealed class BookPublicationService
{
    private readonly IServiceProvider _serviceProvider;

    public BookPublicationService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public string Publish<TBook>(TBook book) where TBook : Book
        => _serviceProvider.GetRequiredService<IBookPublicationStrategy<TBook>>().Publish(book);
}
