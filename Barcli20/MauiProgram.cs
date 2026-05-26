using Microsoft.Extensions.Logging;
#if ANDROID
using Microsoft.Maui.Handlers;
using Android.Widget; // (EditText) - no lo usamos directo, pero ayuda a IntelliSense
#endif

namespace Barcli20
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
#if ANDROID
            builder.ConfigureMauiHandlers(handlers =>
            {
                EntryHandler.Mapper.AppendToMapping("NoSoftKeyboard", (handler, view) =>
                {
                    // Aplica a todos los Entry
                    handler.PlatformView.ShowSoftInputOnFocus = false;
                    handler.PlatformView.Focusable = true;
                    handler.PlatformView.FocusableInTouchMode = true;
                });
            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
