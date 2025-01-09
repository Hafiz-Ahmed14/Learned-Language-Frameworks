// More Practice in String

using System;

class Test {
    public static void Main(string[] args) {
        string s = "My name is Hafiz";
        int cnt_vowel = s.Count(c => "aeiouAEIOU".Contains(c));
        Console.WriteLine("Number of Vowels: " + cnt_vowel);

        int cnt_consonant = s.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));
        Console.WriteLine("Number of Consonant: " + cnt_consonant);

        int digit = s.Count(char.IsDigit);
        Console.WriteLine("Number of Digits: " + digit);
        int special_char = s.Count(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c));
        Console.WriteLine("Number of Special Character: " + cnt_consonant);

    }
}