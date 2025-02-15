using System.Globalization;

namespace ThousandSeparators.Controls
{
    public class CurrencyEntry : Entry
    {
        public static readonly BindableProperty FormattedTextProperty =
            BindableProperty.Create(
                nameof(FormattedText),
                typeof(string),
                typeof(CurrencyEntry),
                default(string),
                propertyChanged: OnFormattedTextChanged);

        public static readonly BindableProperty UseSeparatorProperty =
            BindableProperty.Create(
                nameof(UseSeparator),
                typeof(bool),
                typeof(CurrencyEntry),
                propertyChanged: OnUseSeparatorChanged);

        public string FormattedText
        {
            get => (string)GetValue(FormattedTextProperty);
            set => SetValue(FormattedTextProperty, value);
        }

        public bool UseSeparator
        {
            get => (bool)GetValue(UseSeparatorProperty);
            set => SetValue(UseSeparatorProperty, value);
        }

        public static void OnFormattedTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CurrencyEntry entry && newValue is string newText)
            {
                //entry.Text = FormatWithThousandSeparators(newText);
                if (IsNumericKeyboard(entry.Keyboard) && entry.UseSeparator)
                    entry.Text = FormatWithThousandSeparators(newText);
                else
                    entry.Text = newText;
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Text))
            {
                //FormattedText = Text;
                if (IsNumericKeyboard(Keyboard) && UseSeparator)
                    FormattedText = FormatWithThousandSeparators(Text);
                else
                    FormattedText = Text;
            }
        }

        private static string FormatWithThousandSeparators(string input)
        {
            if (double.TryParse(input, out double number))
            {
                return number.ToString("N0", CultureInfo.InvariantCulture);
            }
            return input;
        }

        private static void OnUseSeparatorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CurrencyEntry entry
                && newValue is bool newSeparatorStatus
                && oldValue is bool oldSeparatorStatus)
            {
                if (newSeparatorStatus != oldSeparatorStatus)
                {
                    if (IsNumericKeyboard(entry.Keyboard) && entry.UseSeparator)
                        entry.Text = FormatWithThousandSeparators(entry.Text);
                }
            }
        }

        private static bool IsNumericKeyboard(Keyboard keyboard)
        {
            return keyboard == Keyboard.Numeric;
        }
    }
}
