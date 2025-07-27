public class MemberCollection
{
    private Member[] members = new Member[100];
    private int count = 0;

    public void Add(Member member)
    {
        members[count++] = member;
    }

    public bool Remove(string fullName)
    {
        for (int i = 0; i < count; i++)
        {
            if (members[i].FullName == fullName)
            {
                members[i] = members[--count];
                return true;
            }
        }
        return false;
    }

    public Member FindByName(string fullName)
    {
        for (int i = 0; i < count; i++)
            if (members[i].FullName == fullName)
                return members[i];
        return null;
    }

    public Member[] GetAllBorrowing(Movie movie)
    {
        Member[] result = new Member[count];
        int resCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (members[i].IsBorrowing(movie))
                result[resCount++] = members[i];
        }
        Member[] output = new Member[resCount];
        for (int i = 0; i < resCount; i++) output[i] = result[i];
        return output;
    }
}
