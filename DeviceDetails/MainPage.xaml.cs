namespace DeviceDetails
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadDeviceInfoAsync();
        }

        private async void LoadDeviceInfoAsync()
        {
#if ANDROID
            var status = await Permissions.CheckStatusAsync<Permissions.Phone>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Phone>();
            }

            // If still not granted
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Needed",
                    "Phone permission is required to get the serial number.", "OK");
            }
#endif

            BindingContext = new DeviceInfoViewModel();
        }
    }

}
