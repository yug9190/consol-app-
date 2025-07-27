public class Movie
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Classification { get; set; }
    public int Duration { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowCount { get; set; }

    public Movie(string title, string genre, string classification, int duration, int totalCopies)
    {
        Title = title;
        Genre = genre;
        Classification = classification;
        Duration = duration;
        TotalCopies = totalCopies;
        AvailableCopies = totalCopies;
        BorrowCount = 0;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Genre: {Genre}, Classification: {Classification}, Duration: {Duration} mins, Available: {AvailableCopies}/{TotalCopies}, Borrowed: {BorrowCount}";
    }
}
