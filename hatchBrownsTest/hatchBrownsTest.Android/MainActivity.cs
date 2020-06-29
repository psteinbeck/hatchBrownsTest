using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace hatchBrownsTest.Droid
{
    [Activity(Label = "hatchBrownsTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public static MainActivity Current { get; private set; }

        public override void OnRequestPermissionsResult(int requestCode, string[]
            permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode,
                permissions, grantResults);
            if (requestCode == 33)
            {
                var importer = (PhotoImporter)Resolver.Resolve<IPhotoImporter>();
                importer.ContinueWithPermission(grantResults[0] ==
                    Permission.Granted);
            }

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}