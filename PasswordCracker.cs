using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordBreakerV2
{
    public static class PasswordCracker
    {
        private static int failedAttempt;
        private static string? myGuess;
        private static char[]? userCharArray;
        private static int sleepSeconds = 2000;
        private static int currentTip;
        private static Random random = new Random();
        private static double secondsItTookToFinish;
        private static char[] passwordCharacters =
            {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i','j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '1','2','3','4','5','6','7','8','9','0','@','!','#','$','%','*'
                ,'(',')','+','=','_','-', '[', ']', ';',};

        /// <summary>
        /// Handle the cracking of the password
        /// Just pass in Console.ReadLine() as the paramater
        /// </summary>
        /// <param name="Pass"></param>
        public static void HandleCrack(string Pass)
        {
            Pass.ToLower();
            Crack(Pass);
        }

        /// <summary>
        /// Custom Console
        /// </summary>
        /// <param name="value"></param>
        public static string Show(string value)
        {
            Console.WriteLine(value);
            return Console.ReadLine();
        }
        /// <summary>
        /// Cracking process
        /// </summary>
        /// <param name="password"></param>
        private static void Crack(string password)
        {
            userCharArray = password.ToCharArray();

            foreach (char userpass in userCharArray)
            {
                secondsItTookToFinish++;
                for (int i = 0; i < passwordCharacters.Length; i++)
                {
                    if (userpass.Equals(passwordCharacters[i]))
                    {
                        myGuess += passwordCharacters[i].ToString();
                    }
                }
                failedAttempt++;
                currentTip = random.Next(0, Tips().Length);
                Console.WriteLine(Tips()[currentTip]);
                Thread.Sleep(sleepSeconds);
                Console.Clear();
            }

            Show($"Your Password is {myGuess}. with a failed attempt of {failedAttempt} press enter to continue");
            Show($"The process took {secondsItTookToFinish} second(s) press enter to continue");
            if(failedAttempt >= 8)
            {
                Show($"Your password is stong... press enter to end");
            }
            else
            {
                Show($"Your password is not stong... press enter to end");
            }
        }
        /// <summary>
        /// Show Tips
        /// </summary>
        /// <returns></returns>
        public static string[] Tips()
        {
            string[] passwordLoadingGuide = new string[]
            {"Cracking..........",
            "Trying New Method............",
            "Random Guessing.................",
            "Problem found!...........",
            "Correcting Problems..................",
            "Creating fake user.................",
            "Accessing records.............",
            "Breaking failsafe.............",};

            return passwordLoadingGuide;
        }
    }
}
