using Android.Text;
using Android.Widget;
using Java.Lang;
using System.Globalization;

namespace ThousandSeparators.Platforms.Android.Controls
{
    public class CurrencyTextWatcher : Java.Lang.Object, ITextWatcher
    {
        private readonly EditText _editText;
        private readonly bool _useSeparator;

        public CurrencyTextWatcher(EditText editText, bool useSeparator)
        {
            _editText = editText;
            _useSeparator = useSeparator;
        }

        public void AfterTextChanged(IEditable s)
        {
            // Handle after text changed event if needed
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            // Handle before text changed event if needed
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            if (!IsNumericKeyboard() || !_useSeparator)
                return; // Skip formatting if the keyboard is not numeric or no separator needed

            string original = s.ToString();

            // Format text and set cursor position
            _editText.RemoveTextChangedListener(this); // Remove listener to prevent infinite loop
            string formatted = FormatWithThousandSeparators(original);

            _editText.Text = formatted;
            _editText.SetSelection(formatted.Length);
            _editText.AddTextChangedListener(this); // Reattach the listener
        }

        private string FormatWithThousandSeparators(string input)
        {
            if (double.TryParse(input, out double number))
            {
                return number.ToString("N0", CultureInfo.InvariantCulture);
            }
            return input;
        }

        private bool IsNumericKeyboard()
        {
            var inputType = _editText.InputType;
            return (inputType & InputTypes.ClassNumber) == InputTypes.ClassNumber ||
                   (inputType & InputTypes.NumberVariationPassword) == InputTypes.NumberVariationPassword;
        }
    }
}
