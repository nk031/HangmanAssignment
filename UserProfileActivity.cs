using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "Profile", Theme = "@style/AppTheme")]
    public class UserProfileActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView Name;
        TextView Coins;
        TextView XP;
        TextView Wins;
        TextView Loses;

        List<Users> activeUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_localprofile);

            // Create your application here
            Init();
        }
        private void Init()
        {
            Name = FindViewById<TextView>(Resource.Id.txtUserProfile_Name);
            Coins = FindViewById<TextView>(Resource.Id.txtUserProfile_Coins);
            XP = FindViewById<TextView>(Resource.Id.txtUserProfile_XP);
            Wins = FindViewById<TextView>(Resource.Id.txtUserProfile_Wins);
            Loses = FindViewById<TextView>(Resource.Id.txtUserProfile_Loses);

            activeUser = Database.LoadActiveUser();

            if (activeUser.Count != 0)
            {
                Name.Text = activeUser[0].username;
                Coins.Text = activeUser[0].coins.ToString();
                XP.Text = activeUser[0].xp.ToString();
                Wins.Text = activeUser[0].wins.ToString();
                Loses.Text = activeUser[0].loses.ToString();
            }

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
    }
}