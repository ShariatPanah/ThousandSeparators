using ThousandSeparators.Controls;

namespace ThousandSeparators
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseThousandSeparators(this MauiAppBuilder appBuilder)
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("CurrencyTextWatcher", (handler, view) =>
            {
#if ANDROID
                if (view is CurrencyEntry entry)
                {
                    handler.PlatformView.EmojiCompatEnabled = false;
                    var editText = handler.PlatformView;
                    editText.AddTextChangedListener(new Platforms.Android.Controls.CurrencyTextWatcher(editText, entry.UseSeparator));
                }
#endif
            });

            return appBuilder;
        }
    }
}
