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
using SQLite;

namespace Hangman
{
    [Table("tblProfile")]
    public class tblProfile
    {
        [PrimaryKey, AutoIncrement, Column("userId")]
        public int userId { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("wins")]
        public int wins { get; set; }
        [Column("loses")]
        public int loses { get; set; }
        [Column("xp")]
        public int xp { get; set; }
        [Column("coins")]
        public int coins { get; set; }
    }
}