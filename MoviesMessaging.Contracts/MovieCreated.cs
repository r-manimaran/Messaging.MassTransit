namespace MoviesMessaging.Contracts;

public record MovieCreated (Guid Id, string Name, string Genre, int YearReleased);
