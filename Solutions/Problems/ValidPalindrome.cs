namespace Solutions.Problems;

public class ValidPalindromeSolution
{
    /// <summary>
    /// Reverse string approach to determine if a given string is a palindrome, considering only alphanumeric characters and ignoring cases.
    /// Time complexity: O(n), where n is the length of the input string. This is because we need to traverse the string once to clean it and then potentially traverse it again to reverse it.
    /// Space complexity: O(n) in the worst case, where n is the length of
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsPalindromeReverse(string s)
    {
        string clean = new([.. s.ToLower().Where(char.IsLetterOrDigit)]);
        string reverse = new([.. clean.Reverse()]);
        return clean == reverse;
    }

    /// <summary>
    /// Two pointers approach to determine if a given string is a palindrome, considering only alphanumeric characters and ignoring cases.
    /// Time complexity: O(n), where n is the length of the input string. This is because we need to traverse the string once to clean it and then potentially traverse it again with the two pointers.
    /// Space complexity: O(n) in the worst case, where n is the length of the input string. This occurs when all characters are alphanumeric and need to be stored in the cleaned string. However, if we consider only the additional space used for variables, it is O(1).
    /// </summary>
    /// <param name="s">The input string to be checked for palindrome properties.</param>
    /// <returns>True if the input string is a palindrome, false otherwise.</returns>
    public bool IsPalindrome(string s)
    {
        string clean = new([.. s.ToLower().Where(char.IsLetterOrDigit)]);
        (int left, int right) = (0, clean.Length - 1);

        while (left < right)
        {
            if (clean[left] != clean[right]) return false;
            left++;
            right--;
        }

        return true;
    }
}
