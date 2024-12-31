namespace ReverseLibrary
{
    public class Reverser
    {
        public static string ReverseNumber(int number)
        {
            return new string(number.ToString().ToCharArray().Reverse().ToArray());
        }

        public static string ReverseString(string text)
        {
            return new string(text.ToCharArray().Reverse().ToArray());
        }
    }
}
