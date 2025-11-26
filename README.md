Thousand Separators in .Net Maui Entry

![2025-02-15_21-27-24](https://github.com/user-attachments/assets/312f63d0-745a-4f20-ae7d-2ec7fac711ff)


How to use:

Add the ThousandSeparators.dll to your project's dependencies, and call UseThousandSeparators() method on MauiAppBuilder in MauiProgram.cs

Then in Xaml file declare a namespace like this:
```
xmlns:entries="clr-namespace:ThousandSeparators.Controls;assembly=ThousandSeparators"

<entries:CurrencyEntry
    HorizontalOptions="Fill"
    Keyboard="Numeric"
    Placeholder="Amount"
    UseSeparator="True" />
```

Hence Keyboard should be set to Numeric and UseSeparator must be True
