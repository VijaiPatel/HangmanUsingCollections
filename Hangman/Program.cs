using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Hangman // hangman
    //add string of hangman into a char array
    // have the user guess the hangman word
    // if the user gets it wrong add a count to the wrong counter
    // if the user gets it right add the char(s) they got right to an array
    //once wrong counter reaches max value or the correct char array for the length of the hangman string matches the hangman array then the game ends.
    // every time the user can input they must be able to see an indication of the word they are guessing using _ for unknown words that are replaced with the correct char as they are guessed.
    // max val of correct= length of hangman string
    // max val of wrong = 10
    // takes user input and adds it to a string array
    //if the string length =1 that means user entered a character, so check for that charecter and how many times it occurs in the char array
    //      if there are no matches then add to wrong counter
    //      else if there are 1 or more matches then add the correct chars to an array
    // else if the string length is >1 then the user attempted to enter a word, so then check if the two strings are exactly the same
    //      if they are the user wins if not add to wrong counter
    //      
{
    class Program
    {
        static void Main(string[] args)
        {
            string hangman = "hello";
            int wordlength= hangman.Length;
            string[] userguess = new string[10];
            int wrongcount = 0;
            char[] ArrayofHangman = hangman.ToCharArray();
            char[] UserChars = new char[wordlength];//chars displayed to user
            bool Iscorrect = false;
            for (int i = 0; i < wordlength; i++)// loops for the length of the hangman string to add ? to the array
            {
                UserChars[i] = '?';//using ? instead of _ to differentiate unknowns as it is easier to read
            }
            //string newhang =new string(ArrayofHangman);// just to prove you can convert a char array to a string
            //Console.WriteLine(newhang);
            //Console.WriteLine(hangman);
            //Console.WriteLine(ArrayofHangman);
            Console.WriteLine($"Welcome to Hangman! You get 10 tries to guess my word. Currently my word is {wordlength} letters long and is represented by:");
            Console.WriteLine(UserChars);
            Console.WriteLine("Each time you guess a letter correctly I wil replace a ? with the correct letter, get them all and you win!");//user instructions
            
            while (wrongcount != 10 && Iscorrect==false) 
            {
                Console.WriteLine($"Currently you know my word has these letters:");
                Console.WriteLine(UserChars);// shows what letters the user has correct and their position as well as the ones they don't
                Console.WriteLine("Enter a Letter or Word");     
                string guessthistime= Console.ReadLine();
                userguess[wrongcount] = guessthistime;
                //Console.WriteLine(userguess[wrongcount]);
                if (guessthistime.Length>1)// if the length of the string given by user is greater than 1 we know they tried to enter a word
                {
                    //if the word is correct
                    if (guessthistime == hangman)// if statement to set condition to break loop when th correct word is guessed. 
                    
                    {
                        Iscorrect = true;//breaks the loop if the user has the correct word
                    }
                    else
                    {
                        Console.WriteLine($"The word you entered: {guessthistime}. Was not my word");// tells the user they got the word wrong
                    }
                }
                else
                {
                    int NumberOfCorrectCharsThisTime = 0;
                    for (int i = 0;i < wordlength; i++)
                    {
                        if (guessthistime == ArrayofHangman[i].ToString())//checks if each value in the hangman char array is equal to the user input
                        {
                            UserChars[i] = ArrayofHangman[i];// copies the correctly guessed letter into the UserChars Array at the corrct position
                            Console.WriteLine("Congratulations you got a letter right. You now know my word contains:");
                            Console.WriteLine(UserChars);
                            NumberOfCorrectCharsThisTime++;
                        }
                    }
                    if (NumberOfCorrectCharsThisTime ==0)
                    {
                        Console.WriteLine($"your guess of {guessthistime} was not in my word.");
                    }
                    string completehang =new string(UserChars);// turns user char array of the correct chars so for into a string so that you can compare to hangman word
                    if (hangman==completehang)// if the user has the correct word by guessing all the chars then exits the loop
                    {
                        Console.WriteLine($"Congratulations you correctly guessed the word: {hangman}");
                        Iscorrect =true;
                    }
                }

                Console.WriteLine($"You have currently guessed {wrongcount+1} times. Your current guesses are:");//tells the user all the guesses they have made
                for (int i = 0; i < wrongcount+1; i++)
                {
                    Console.WriteLine(userguess[i]);
                }
                wrongcount++;
            }
            if(Iscorrect==false)
            {
                Console.WriteLine($"Uh oh you're out of tries! the correct word was: '{hangman}' better luck next time");
            }
            else
            {
                Console.WriteLine($"Congratulations you correctly guessed the word: '{hangman}'");
            }
            
            
        }

    }
}