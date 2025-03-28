namespace SafeVault.src.SafeVault.Helpers;

public static class ValidationHelpers
{
    public static bool IsValidInput(string input, string allowedSpecialCharacters = "")
    {
        if (string.IsNullOrEmpty(input))
            return false;

        var validCharacters = allowedSpecialCharacters.ToHashSet();
        return input.All(c => char.IsLetterOrDigit(c) || validCharacters.Contains(c));
    }

    public static bool IsValidXSSInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;

        // We don't want to allow input with <script or <iframe
        if (input.ToLower().Contains("<script") || input.ToLower().Contains("<iframe"))
            return false;

        return true;
    }
}