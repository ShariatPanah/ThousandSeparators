using Microsoft.Extensions.Logging;
using ThousandSeparators.Controls;

namespace ThousandSeparators
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("CustomTextWatcher", (handler, view) =>
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
