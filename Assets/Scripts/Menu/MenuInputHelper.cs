using TMPro;

namespace MemoryCardGame.Menu
{
    public static class MenuInputHelper
    {
        public static int ReadInput(TMP_InputField inputField, int defaultValue)
        {
            var inputValue = inputField.text;

            if (string.IsNullOrEmpty(inputValue))
                return defaultValue;

            return int.TryParse(inputValue, out int value) ? value : defaultValue;
        }
    }
}