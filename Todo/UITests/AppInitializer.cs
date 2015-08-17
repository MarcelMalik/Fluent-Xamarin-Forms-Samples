using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Utils;
using System.Reflection;

namespace Todo.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp (Platform platform)
        {
            var apiKey = "YOUR_API_KEY_HERE";
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    //.ApkFile (PathToAPK ())
                    .ApiKey (apiKey)
                    .StartApp ();
            } else if (platform == Platform.iOS)
            {
                return ConfigureApp.iOS
                    //.AppBundle (PathToIPA ())
                    .ApiKey (apiKey)
                    .StartApp ();
            }
            return null;
        }

        /*private static string PathToAPK ()
        {
            var currentFile = new Uri (Assembly.GetExecutingAssembly ().CodeBase).LocalPath;
            var fi = new FileInfo (currentFile);
            var dir = fi.Directory.Parent.Parent.Parent.FullName;
            return Path.Combine (dir, "Droid", "bin", "Debug", "FluentXamarinForms.Samples.Todo.apk");
        }

        private static string PathToIPA ()
        {
            var currentFile = new Uri (Assembly.GetExecutingAssembly ().CodeBase).LocalPath;
            var fi = new FileInfo (currentFile);
            var dir = fi.Directory.Parent.Parent.Parent.FullName;
            return Path.Combine(dir, "iOS", "bin", "iPhoneSimulator", "Debug", "Todo.iOS.app");
        }*/
    }
}