Thousand Separators in .Net Maui Entry

![2025-02-15_21-27-24](https://github.com/user-attachments/assets/312f63d0-745a-4f20-ae7d-2ec7fac711ff)


how to use:
add the ThousandSeparators.dll to your project's dependencies, then in Xaml file declare a namespace like this:
```
xmlns:controls="clr-namespace:ThousandSeparators.Controls"

<controls:CurrencyEntry
    HorizontalOptions="Fill"
    Keyboard="Numeric"
    Placeholder="Amount"
    UseSeparator="True" />
```
