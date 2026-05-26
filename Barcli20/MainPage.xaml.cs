namespace Barcli20
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
#if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoKeyboard", (handler, view) =>
            {
                if (view == codigoEntry)
                {
                    // Accede al control nativo de Android y le apaga el teclado virtual
                    handler.PlatformView.ShowSoftInputOnFocus = false;
                }
            });
#endif
        }
        private void OnCodigoCompleted(object sender, EventArgs e) { }
        private void codigoEntry_TextChanged(object sender, TextChangedEventArgs e) { }
        private void codigoEntry_Focused(object sender, FocusEventArgs e) { }

    }
}
