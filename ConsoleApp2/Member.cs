public class Member
{
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    private Movie[] borrowedMovies = new Movie[10];
    private int count = 0;

    public Member(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phone;
    }

    public string FullName => $"{FirstName} {LastName}";

    public bool BorrowMovie(Movie movie)
    {
        if (count >= 10 || movie.AvailableCopies <= 0) return false;
        borrowedMovies[count++] = movie;
        movie.AvailableCopies--;
        movie.BorrowCount++;
        return true;
    }

    public bool ReturnMovie(Movie movie)
    {
        for (int i = 0; i < count; i++)
        {
            if (borrowedMovies[i] == movie)
            {
                borrowedMovies[i] = borrowedMovies[--count];
                movie.AvailableCopies++;
                return true;
            }
        }
        return false;
    }

    public Movie[] GetBorrowedMovies()
    {
        Movie[] result = new Movie[count];
        for (int i = 0; i < count; i++) result[i] = borrowedMovies[i];
        return result;
    }

    public bool IsBorrowing(Movie movie)
    {
        for (int i = 0; i < count; i++)
        {
            if (borrowedMovies[i] == movie) return true;
        }
        return false;
    }
}
