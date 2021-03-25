using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Service.Autofill;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "Hangman", Theme = "@style/AppTheme")]
    public class GameplayActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        // Keys
        Button btnA;
        Button btnB;
        Button btnC;
        Button btnD;
        Button btnE;
        Button btnF;
        Button btnG;
        Button btnH;
        Button btnI;
        Button btnJ;
        Button btnK;
        Button btnL;
        Button btnM;
        Button btnN;
        Button btnO;
        Button btnP;
        Button btnQ;
        Button btnR;
        Button btnS;
        Button btnT;
        Button btnU;
        Button btnV;
        Button btnW;
        Button btnX;
        Button btnY;
        Button btnZ;

        // Front End Components - Displayed in chronological order
        TextView txtWord;
        ImageView imgHangman;
        TextView txtWinLose;
        Button[] Keys;
        Button btnReset;

        // Global Variables
        char[] chosenWordArray;
        char[] chosenWordUnderscoreArray;
        string chosenWord;
        int IncorrectCount;

        List<Users> activeUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.activity_gameplay);

            Init();
        }
        private void Init()
        {
            // Initialize Components
            txtWord = FindViewById<TextView>(Resource.Id.txtWord);
            imgHangman = FindViewById<ImageView>(Resource.Id.imgHangman);
            txtWinLose = FindViewById<TextView>(Resource.Id.txtWinLose);

            btnReset = FindViewById<Button>(Resource.Id.btnReset);
            btnReset.Click += btnReset_Click;

            activeUser = Database.LoadActiveUser();

            keyboardInit();
            ResetState();

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
        private void keyboardInit()
        {
            // Define Keys
            Keys = new Button[] {
                btnQ,
                btnW,
                btnE,
                btnR,
                btnT,
                btnY,
                btnU,
                btnI,
                btnO,
                btnP,
                btnA,
                btnS,
                btnD,
                btnF,
                btnG,
                btnH,
                btnJ,
                btnK,
                btnL,
                btnZ,
                btnX,
                btnC,
                btnV,
                btnB,
                btnN,
                btnM
            };
            // Define KeyIDs from Resource file
            int[] KeyIDs = new int[] {
                Resource.Id.btnQ,
                Resource.Id.btnW,
                Resource.Id.btnE,
                Resource.Id.btnR,
                Resource.Id.btnT,
                Resource.Id.btnY,
                Resource.Id.btnU,
                Resource.Id.btnI,
                Resource.Id.btnO,
                Resource.Id.btnP,
                Resource.Id.btnA,
                Resource.Id.btnS,
                Resource.Id.btnD,
                Resource.Id.btnF,
                Resource.Id.btnG,
                Resource.Id.btnH,
                Resource.Id.btnJ,
                Resource.Id.btnK,
                Resource.Id.btnL,
                Resource.Id.btnZ,
                Resource.Id.btnX,
                Resource.Id.btnC,
                Resource.Id.btnV,
                Resource.Id.btnB,
                Resource.Id.btnN,
                Resource.Id.btnM
            };
            // Bind Keys to View using KeyIDs
            for (int i = 0; i < KeyIDs.Length; i++)
            {
                Keys[i] = FindViewById<Button>(KeyIDs[i]);
            }
            // Bind functions to Keys
            foreach (Button key in Keys)
            {
                key.Click += Key_Click;

            }
        }
        private void Key_Click(object sender, EventArgs e)
        {
            Button keyPressed = (Button)sender;
            // Disable Key
            keyPressed.Enabled = false;
            // Pass through keyPressed.Text
            GamePlay(keyPressed.Text.ToLower());
        }
        private void ResetState()
        {
            // Clear Text
            txtWord.Text = string.Empty;
            txtWinLose.Text = string.Empty;
            // Reset IncorrectCount
            IncorrectCount = 0;
            // Reset Image
            imgHangman.SetImageResource(Resource.Drawable.hangman0);
            // Enable all Keys
            KeysEnabled(true);
            // Disable Reset Button
            btnReset.Enabled = false;
            // Load New Word
            LoadWord();
        }
        private void KeysEnabled(bool clause)
        {
            foreach (Button key in Keys)
            {
                key.Enabled = clause;
            }
        }
        private void LoadWord()
        {
            // Get Random Word from the class
            chosenWord = GameplayOperations.GetRandomWord();
            // Grab the random word and turn it to a char array - of individual letters
            chosenWordArray = chosenWord.ToCharArray();

            // Array that holds all the underscores _ _ _
            chosenWordUnderscoreArray = new char[chosenWordArray.Length];
            for (int i = 0; i < chosenWordArray.Length; i++)
            {
                chosenWordUnderscoreArray[i] = '_';
                txtWord.Text += $@"{chosenWordUnderscoreArray[i]} ";
            }

            UpdateImage();
        }
        private void GamePlay(string Letter)
        {
            //if our word contains a letter clicked on by the button
            if (chosenWord.Contains(Letter))
            {//go through each letter in the word to find it (or them if more than one)
                for (int i = 0; i < chosenWordArray.Length; i++)
                {
                    if (Letter == chosenWordArray[i].ToString())//if the letter int eh word equals the one clicked on
                    {//change the underscore at that place to the letter so _ _ _ A _
                        chosenWordUnderscoreArray[i] = Convert.ToChar(Letter);
                        UpdateImage();
                        CheckWin();
                    }
                }
            }
            else
            {
                IncorrectCount++;
                UpdateImage();
                return;
            }

            txtWord.Text = string.Empty; //clear out the text

            foreach (var letter in chosenWordUnderscoreArray)
            {
                txtWord.Text += letter + " "; //add the underscores and the new letters to the screen

            }
        }
        private void UpdateImage()
        {
            switch (IncorrectCount)
            {
                case 0:
                    imgHangman.SetImageResource(Resource.Drawable.hangman0);
                    break;
                case 1:
                    imgHangman.SetImageResource(Resource.Drawable.hangman1);
                    break;
                case 2:
                    imgHangman.SetImageResource(Resource.Drawable.hangman2);
                    break;
                case 3:
                    imgHangman.SetImageResource(Resource.Drawable.hangman3);
                    break;
                case 4:
                    imgHangman.SetImageResource(Resource.Drawable.hangman4);
                    break;
                case 5:
                    imgHangman.SetImageResource(Resource.Drawable.hangman5);
                    break;
                case 6:
                    imgHangman.SetImageResource(Resource.Drawable.hangman6);
                    break;
                case 7:
                    imgHangman.SetImageResource(Resource.Drawable.hangman7);
                    break;
                case 8:
                    imgHangman.SetImageResource(Resource.Drawable.hangman8);
                    break;
                case 9:
                    imgHangman.SetImageResource(Resource.Drawable.hangman9);
                    break;
                case 10:
                    imgHangman.SetImageResource(Resource.Drawable.hangman10);
                    break;
                case 11:
                    txtWinLose.Text = $@"You Lose! The word was {chosenWord}";
                    // Disable Keys
                    KeysEnabled(false);
                    // Enable Reset Button
                    btnReset.Enabled = true;

                    activeUser[0].loses++;

                    if (activeUser[0].username != null)
                    {
                        Database.UpdateUser(activeUser);
                    }
                    break;
            }
        }
        private void CheckWin()
        {
            if (chosenWordArray.SequenceEqual(chosenWordUnderscoreArray))
            {
                txtWinLose.Text = "You Win!";
                // Disable Keys
                KeysEnabled(false);
                // Enable Reset Button
                btnReset.Enabled = true;

                activeUser[0].wins++;

                int tempXP = (12 / (IncorrectCount + 1)) * chosenWord.Length;

                activeUser[0].xp = activeUser[0].xp + tempXP;


                if (activeUser[0].username != null)
                {
                    Database.UpdateUser(activeUser);
                    Toast.MakeText(this, "You Win!", ToastLength.Long).Show();
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetState();
        }
    }
}