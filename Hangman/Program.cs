﻿using System;
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
            string[] userguess = new string[10];
            int wrongcount = 0;
            char[] ArrayofHangman = hangman.ToCharArray();
            char[] UserChars = new char[hangman.Length];//chars displayed to user
            bool Iscorrect = false;
            for (int i = 0; i < hangman.Length; i++)// loops for the length of the hangman string to add ? to the array
            {
                UserChars[i] = '?';//using ? instead of _ to differentiate unknowns as it is easier to read
            }
            string newhang =new string(ArrayofHangman);// just to prove you can convert a char array to a string
            //Console.WriteLine(newhang);
            //Console.WriteLine(hangman);
            //Console.WriteLine(ArrayofHangman);
            Console.WriteLine($"Welcome to Hangman! Currently my word is {hangman.Length} long and is represented by: {UserChars} can you guess the word in 10 tries?");
            Console.WriteLine("Each time you guess a letter correctly I wil replace a ? with the correct letter, get them all and you win!");//user instructions
            
            while (wrongcount != 10 && Iscorrect==false) 
            {
                Console.WriteLine($"Currently you know my word has: {UserChars}");
                Console.WriteLine("Enter a Letter or Word");
                userguess[wrongcount] = Console.ReadLine();
                //Console.WriteLine(userguess[wrongcount]);
                if (userguess[wrongcount].Length>1)// if the length of the string given by user is greater than 1 we know they tried to enter a word
                {
                    //if the word is correct
                    if (UserChars == ArrayofHangman || userguess[wrongcount] == newhang)// if statement to set condition to break loop when either correct word is guessed or all individual chars have been guessed. 
                    // using newhang just to prove that in a case where you only get given a char array you can convert it to a string to perform this logic check
                    {
                        Console.WriteLine($"Congratulations you correctly guessed the word: {hangman}");
                        Iscorrect = true;
                    }
                    else
                    {
                        Console.WriteLine($"The word you entered: {userguess[wrongcount]}. Was not my word");
                    }
                }
                
                wrongcount++;
            }
            if(Iscorrect==false)
            {
                Console.WriteLine($"Uh oh you're out of tries! the correct word was {hangman} better luck next time");
            }
            
        }

    }
}