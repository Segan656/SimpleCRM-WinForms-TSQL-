
using System.Text.RegularExpressions;


namespace TestTask
{
    static class Validation
    {
        public static bool IsWord(string str)
        {
            return string.IsNullOrEmpty(str) || Regex.IsMatch(str, @"^[а-яёА-ЯЁ]*$");
        }
        public static bool IsPhrase(string str)
        {
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^[a-zа-яёA-ZА-ЯЁ]{1,32}([ -][a-zа-яёA-ZА-ЯЁ]{1,32})*$");
        }

        public static bool IsCode(string str)
        {
            return string.IsNullOrEmpty(str) || Regex.IsMatch(str, @"^[a-zA-Z0-9]{1,10}$");
        }
        public static bool IsDepartment(string str)
        {
            return string.IsNullOrEmpty(str) || Regex.IsMatch(str, @"^[a-zа-яёA-ZА-ЯЁ]{1,32}([ -][a-zа-яёA-ZА-ЯЁ]{1,32})*$");
        }
    }
}
