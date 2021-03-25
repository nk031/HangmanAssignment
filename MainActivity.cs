using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Views;
using System.Collections.Generic;

namespace Hangman
{
    [Activity(Label = "Hangman", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        Button btnPlay;
        EditText txtUsername;

        List<Users> activeUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // If UserProfile exists, send them straight to the GamePlay, otherwise create account here.
            activeUser = Database.LoadActiveUser();

            if (activeUser.Count == 0)
            {
                SetContentView(Resource.Layout.activity_home);
                Init();
            }
            else
            {
                StartActivity(typeof(GameplayActivity));
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void Init()
        {
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnPlay.Click += btnPlay_Click;

            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_play:
                    StartActivity(typeof(MainActivity));
                    return true;
                case Resource.Id.navigation_leaderboard:
                    StartActivity(typeof(LeaderboardActivity));
                    return true;
                case Resource.Id.navigation_profile:
                    StartActivity(typeof(UserProfileActivity));
                    return true;
            }
            return false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != String.Empty)
            {
                Database.CreateProfile(txtUsername.Text);
                StartActivity(typeof(GameplayActivity));
            }
            else
            {
                Toast.MakeText(this, "Please Enter Your Name!", ToastLength.Long).Show();//player will add name to start game
            }
        }
    }
}