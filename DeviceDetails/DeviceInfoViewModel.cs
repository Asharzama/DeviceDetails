using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDetails
{
    public class DeviceInfoViewModel
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }
        public string DeviceType { get; set; }
        public string SerialNumber { get; set; }

        public DeviceInfoViewModel()
        {
            Model = $"Model: {DeviceInfo.Model}";
            Manufacturer = $"Manufacturer: {DeviceInfo.Manufacturer}";
            Name = $"Device Name: {DeviceInfo.Name}";
            Version = $"OS Version: {DeviceInfo.VersionString}";
            Platform = $"Platform: {DeviceInfo.Platform}";
            Idiom = $"Idiom: {DeviceInfo.Idiom}";
            DeviceType = $"Device Type: {DeviceInfo.DeviceType}";
            SerialNumber = $"Serial Number: {GetDeviceId()}";
        }

        private string GetDeviceId()
        {
#if ANDROID
        var context = Android.App.Application.Context;
        var androidId = Android.Provider.Settings.Secure.GetString(
            context.ContentResolver,
            Android.Provider.Settings.Secure.AndroidId
        );
        return $"ANDROID-{androidId}";

#elif IOS
        var identifier = UIKit.UIDevice.CurrentDevice.IdentifierForVendor?.AsString();
        return $"IOS-{identifier}";

#elif WINDOWS
            return $"WIN-{System.Security.Principal.WindowsIdentity.GetCurrent().User?.Value}";

#else
        return "UNKNOWN-DEVICE";
#endif
        }

    }
}

