namespace Algorithms.Codewars.API.DataManager.Interfaces
{
    public interface INoviceLevel
    {
        bool IsValidIP(string ipAddres);

        int[] MakeTheDeadfishSwim(string data);

        string GetReadableTime(int seconds);

        int DuplicateCount(string str);

        IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable);

        string FirstNonRepeatingLetter(string s);

        string ToWeirdCase(string s);
    }
}
