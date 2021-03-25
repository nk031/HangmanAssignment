using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    [Table("tblLeaderboard")]
    public class tblLeaderboard
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Wins")]
        public int Wins { get; set; }
        [Column("Loses")]
        public int Loses { get; set; }
    }
}