using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase.Firestore;
using Firebase;

namespace book_exchange.Droid
{
    [Activity(Label = "book_exchange", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            LoadApplication(new App());

            FirebaseFirestore database = GetDataBase();
        }

        public FirebaseFirestore GetDataBase()
        {
            FirebaseFirestore database;

            var options = new FirebaseOptions.Builder()
                .SetProjectId("book-exchange-6ea4c")
                .SetApplicationId("book-exchange-6ea4c")
                .SetApiKey("AIzaSyDX3QsgZtmGYiiQ-BGM1qcVk_1Mr_wY3b0")
                .SetDatabaseUrl("https://book-exchange-6ea4c-default-rtdb.firebaseio.com")
                .SetStorageBucket("book-exchange-6ea4c")
                .Build();

            var app = FirebaseApp.InitializeApp(this, options);
            database = FirebaseFirestore.GetInstance(app);

            return database;

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}