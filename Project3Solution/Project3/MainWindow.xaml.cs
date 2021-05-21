using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameInfo;
using System.IO;


namespace Project3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        static string filePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Game Data.csv";

        static int countLines = GetCount(filePath); //Get the quantity of lines in file for the length of the array 

        Game[] game = GetGame(filePath, countLines);

        static int GetCount(string file)
        {
            int count = 0; //Count = 0

            FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read); //Open file, set to read
            StreamReader readerCount = new StreamReader(sr); //StreamReader

            string stringRead = readerCount.ReadLine(); //Read the header, header is NOT part of the count

            while (stringRead != null) //While stringRead is not equal to null
            {
                ++count; //count +1
                stringRead = readerCount.ReadLine(); //Read the next line

            }

            readerCount.Close(); //Close reader
            sr.Close(); //Close file

            return count; //return value to count variable
        }


        static Game[] GetGame(string filePath, int count)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //Create new filestream
            StreamReader readerGame = new StreamReader(fs); //New streamreader, pass filestream as argument

            string stringRead = readerGame.ReadLine(); //Read the header, do nothing with headers

            Game[] gameCreate = new Game[count]; //count has no value yet


            for (int counter = 1; counter < count; ++counter) //Header has been read.
            {
                stringRead = readerGame.ReadLine(); //Read the entire line

                string[] Parts = stringRead.Split(",");

                gameCreate[counter] = new Game();

                gameCreate[counter].Title = Parts[0]; //Each element = a field value of that Game

                gameCreate[counter].Gamemode = Parts[1];  //Set each class variable to the corrosponding part of csv
                gameCreate[counter].Genre1 = Parts[2];
                gameCreate[counter].Genre2 = Parts[3];
                gameCreate[counter].Genre3 = Parts[4];
                gameCreate[counter].Price = Parts[5];
            }//for




            readerGame.Close(); //Close StreamReader
            fs.Close(); //Close File

            return gameCreate;
        }//GetGame




        static void ClearGrid(ListView GameList) //Must pass the control to created methods
        {
            int quanRows = GameList.Items.Count; //Count items in Game list

            for (int counter = quanRows - 1; counter >= 0; --counter) //For counter equals quanrows -1, and counter >= 0, subtract from counter
            {
                GameList.Items.RemoveAt(counter); //Removes element specified to list
            }//for
        }//ClearGrid


        static void MakeVisible(ListView GameList)
        {
            if (GameList.Visibility == Visibility.Hidden) //If list is hidden
            {
                GameList.Visibility = Visibility.Visible; //Make list visible
            }//if
        }//Make Visible

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
        private void btnGamemode_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid(GameList);
            MakeVisible(GameList);

            string chosen = "";

            try
            {
                ComboBoxItem chosenItem = (ComboBoxItem)cboxGamemode.SelectedItem; //Did the user choose a mode? If so, get the chosen "item"
                chosen = chosenItem.Content.ToString(); //Chosen gamemode is set to variable chosen

               
            }
            catch
            {
                MessageBox.Show("Choose a gamemode");
                return;
            }

            //get quantity of checked genres
            int quanGenres = 0;
            if ((bool)checkboxAction.IsChecked) { ++quanGenres; }
            if ((bool)checkboxAdventure.IsChecked) { ++quanGenres; }
            if ((bool)checkboxBattleRoyale.IsChecked) { ++quanGenres; }
            if ((bool)checkboxCasual.IsChecked) { ++quanGenres; }
            if ((bool)checkboxFPS.IsChecked) { ++quanGenres; }
            if ((bool)checkboxFighting.IsChecked) { ++quanGenres; }
            if ((bool)checkboxPlatformer.IsChecked) { ++quanGenres; }
            if ((bool)checkboxRPG.IsChecked) { ++quanGenres; }
            if ((bool)checkboxRoguelike.IsChecked) { ++quanGenres; }
            if ((bool)checkboxRacing.IsChecked) { ++quanGenres; }
            if ((bool)checkboxSoulslike.IsChecked) { ++quanGenres; }
            if ((bool)checkboxStrategy.IsChecked) { ++quanGenres; }
            if ((bool)checkboxSandbox.IsChecked) { ++quanGenres; }
            if ((bool)checkboxHorror.IsChecked) { ++quanGenres; }
            if ((bool)checkboxRhythm.IsChecked) { ++quanGenres; }
            if ((bool)checkboxOpenWorld.IsChecked) { ++quanGenres; }
            

            //make the collection of genres
            string[] qenreChecked = new string[quanGenres];

            int count = 0;
            if ((bool)checkboxAction.IsChecked) { qenreChecked[count] = checkboxAction.Content.ToString(); ++count; }
            if ((bool)checkboxAdventure.IsChecked) { qenreChecked[count] = checkboxAdventure.Content.ToString(); ++count; }
            if ((bool)checkboxBattleRoyale.IsChecked) { qenreChecked[count] = checkboxBattleRoyale.Content.ToString(); ++count; }
            if ((bool)checkboxCasual.IsChecked) { qenreChecked[count] = checkboxCasual.Content.ToString(); ++count; }
            if ((bool)checkboxFPS.IsChecked) { qenreChecked[count] = checkboxFPS.Content.ToString(); ++count; }
            if ((bool)checkboxFighting.IsChecked) { qenreChecked[count] = checkboxFighting.Content.ToString(); ++count; }
            if ((bool)checkboxPlatformer.IsChecked) { qenreChecked[count] = checkboxPlatformer.Content.ToString(); ++count; }
            if ((bool)checkboxRPG.IsChecked) { qenreChecked[count] = checkboxRPG.Content.ToString(); ++count; }
            if ((bool)checkboxRoguelike.IsChecked) { qenreChecked[count] = checkboxRoguelike.Content.ToString(); ++count; }
            if ((bool)checkboxRacing.IsChecked) { qenreChecked[count] = checkboxRacing.Content.ToString(); ++count; }
            if ((bool)checkboxSoulslike.IsChecked) { qenreChecked[count] = checkboxSoulslike.Content.ToString(); ++count; }
            if ((bool)checkboxStrategy.IsChecked) { qenreChecked[count] = checkboxStrategy.Content.ToString(); ++count; }
            if ((bool)checkboxSandbox.IsChecked) { qenreChecked[count] = checkboxSandbox.Content.ToString(); ++count; }
            if ((bool)checkboxHorror.IsChecked) { qenreChecked[count] = checkboxHorror.Content.ToString(); ++count; }
            if ((bool)checkboxRhythm.IsChecked) { qenreChecked[count] = checkboxRhythm.Content.ToString(); ++count; }
            if ((bool)checkboxOpenWorld.IsChecked) { qenreChecked[count] = checkboxOpenWorld.Content.ToString(); ++count; }
            
            

            

            var queryResults = from g in game//What does this sequence do????
                               where g?.Gamemode == chosen // "?" allows this variable to be null

                               select g;  //Grab the whole object




            foreach (var GameTitle in queryResults) //For each title in queryresults
            {
                bool keepIt = false;  //start with assumption that none of the genres were checked for this game
                for(int c = 0; c < qenreChecked.Length; ++c)
                {
                    if(qenreChecked[c] == GameTitle.Genre1 || qenreChecked[c] == GameTitle.Genre2 || qenreChecked[c] == GameTitle.Genre3)
                    {
                        keepIt = true;
                        
                    }
                }

                if (keepIt)
                {
                    GameList.Items.Add(new Game()
                    {
                        Title = GameTitle.Title,
                        Gamemode = GameTitle.Gamemode,
                        Genre1 = GameTitle.Genre1,
                        Genre2 = GameTitle.Genre2,
                        Genre3 = GameTitle.Genre3,
                        Price = GameTitle.Price
                    }); // Yeah idk what is going on anymore
                }
            }//For Each
        }//button Gamemode_Click



        private void btnClearCheckboxes_Click(object sender, RoutedEventArgs e)
        {
            checkboxAction.IsChecked = false;
            checkboxAdventure.IsChecked = false;
            checkboxBattleRoyale.IsChecked = false;
            checkboxCasual.IsChecked = false;
            checkboxFPS.IsChecked = false;
            checkboxHorror.IsChecked = false;
            checkboxOpenWorld.IsChecked = false;
            checkboxPlatformer.IsChecked = false;
            checkboxRPG.IsChecked = false;
            checkboxRhythm.IsChecked = false;
            checkboxSoulslike.IsChecked = false;
            checkboxRoguelike.IsChecked = false;
            checkboxSandbox.IsChecked = false;
            checkboxRacing.IsChecked = false;
            checkboxStrategy.IsChecked = false;
            checkboxSandbox.IsChecked = false;

        }
        
    }
}
