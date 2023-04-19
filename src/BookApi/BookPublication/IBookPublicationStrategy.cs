namespace BookApi.BookPublication;

public interface IBookPublicationStrategy<TBook> where TBook : Book
{
    string Publish(TBook book);
}

public class APublicationStrategy : IBookPublicationStrategy<BookA>
{
    public string Publish(BookA book) => $"Published book {book.Name} with method A";
}

public class BPublicationStrategy : IBookPublicationStrategy<BookB>
{
    public string Publish(BookB book) => $"Published book {book.Name} with method B";
}