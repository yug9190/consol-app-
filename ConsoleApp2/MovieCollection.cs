public class MovieCollection
{
    private Movie[] movies = new Movie[100];
    private int count = 0;

    public void Add(Movie movie)
    {
        for (int i = 0; i < count; i++)
            if (movies[i].Title == movie.Title)
                return;

        movies[count++] = movie;
    }

    public bool Remove(string title)
    {
        for (int i = 0; i < count; i++)
        {
            if (movies[i].Title == title)
            {
                movies[i] = movies[--count];
                return true;
            }
        }
        return false;
    }

    public Movie FindByTitle(string title)
    {
        for (int i = 0; i < count; i++)
            if (movies[i].Title == title)
                return movies[i];
        return null;
    }

    public Movie[] GetAllSorted()
    {
        Movie[] result = new Movie[count];
        for (int i = 0; i < count; i++) result[i] = movies[i];

        for (int i = 0; i < count - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < count; j++)
                if (string.Compare(result[j].Title, result[min].Title) < 0)
                    min = j;

            if (min != i)
            {
                Movie temp = result[i];
                result[i] = result[min];
                result[min] = temp;
            }
        }
        return result;
    }

    public Movie[] Top3Movies()
    {
        Movie[] top = new Movie[3];
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (top[j] == null || movies[i].BorrowCount > top[j].BorrowCount)
                {
                    for (int k = 2; k > j; k--)
                        top[k] = top[k - 1];
                    top[j] = movies[i];
                    break;
                }
            }
        }
        return top;
    }
}
