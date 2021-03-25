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
    [Table("Users")]
    public class Users
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int id { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("active")]
        public string active { get; set; }
        [Column("wins")]
        public int wins { get; set; }
        [Column("loses")]
        public int loses { get; set; }
        [Column("coins")]
        public int coins { get; set; }
        [Column("xp")]
        public int xp { get; set; }
    }
}