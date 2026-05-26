using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;

namespace Barcli20
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            EnableKioskMode();
        }

        protected override void OnResume()
        {
            base.OnResume();
            EnableKioskMode();
        }

        public override void OnBackPressed()
        {
            // Bloquea el botón físico/virtual de retroceso para evitar salir de la app.
        }

        private void EnableKioskMode()
        {
            var window = Window;
            if (window is null)
            {
                return;
            }

            WindowCompat.SetDecorFitsSystemWindows(window, false);
            var insetsController = WindowCompat.GetInsetsController(window, window.DecorView);

            if (insetsController is not null)
            {
                insetsController.Hide(WindowInsetsCompat.Type.SystemBars());
                insetsController.SystemBarsBehavior = WindowInsetsControllerCompat.BehaviorShowTransientBarsBySwipe;
            }

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                StartLockTask();
            }
        }
    }
}
