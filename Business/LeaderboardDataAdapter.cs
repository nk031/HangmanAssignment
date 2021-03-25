using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    class LeaderboardDataAdapter : BaseAdapter<Users>
    {
        private readonly Activity context;
        private readonly List<Users> items;

        public LeaderboardDataAdapter(Activity context, List<Users> items)
        {
            this.context = context;
            this.items = items;
        }


        public override Users this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null)
            {// no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.LeaderboardItem, null);
                view.FindViewById<TextView>(Resource.Id.leaderboard_txtUsername).Text = $@"{item.username}";
                view.FindViewById<TextView>(Resource.Id.leaderboard_txtWins).Text = $@"{item.wins}";
                view.FindViewById<TextView>(Resource.Id.leaderboard_txtLoses).Text = $@"{item.loses}";
            }
            return view;
        }
    }
}