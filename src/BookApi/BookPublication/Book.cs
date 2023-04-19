namespace BookApi.BookPublication;

public abstract record Book(string Name);

public sealed record BookA(string Name) : Book(Name);

public sealed record BookB(string Name) : Book(Name);
