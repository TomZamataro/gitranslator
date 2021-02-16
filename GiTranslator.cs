using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Git_Path_Translator
{
    class Program
    {
        #region Functions
        static void actuallyResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Write(".");
            Console.Clear();
        }
        #endregion
        #region Global Variables
        static string path;
        static bool repetTranslation;
        static bool repetAfterExcep;
        #endregion
        [STAThread] // don't know what it does, but its needed, classic right?
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Path Translator for Git Bash - Maded By Tom Zamataro da Fonseca"; // just some credit to me, that no one is going to see, classic right?
            Console.Clear();
            // set up for the APL loop
            do
            {
                repetTranslation = false;
                path = "";
                Console.WriteLine("\n   Inform the path you would like to translate to Git Bash syntax:");
                Console.Write("\n   "); // just for aesthetics, class... sory, no more                                                         classic joke tho, right? yes, I've a lot of shit in my head
                // set up for the exception handling loop
                do
                {
                    repetAfterExcep = false;
                    try
                    {
                        if (path == "")
                        {
                            path = Console.ReadLine();
                        }
                        #region The Translation
                        string[] metaChars = new string[] { @"\", " ", "<", ">", "&", ";","*",
                        "?", "#", ".", "~", "|", "!", "$", "(", ")", "[", "]", "{", "}", "'", "\"" }; // the meta characters that I've to deal with
                        foreach (string meta in metaChars)
                        {
                            // backslash is the special case in this contex
                            if (meta == @"\") { path = path.Replace(meta, "/"); }
                            // the rest
                            else { path = path.Replace(meta, $@"\{meta}"); }
                        }
                        path = path.Trim(new char[] { '\'', '"' }); // jusr making sure, ..., what? I didn't say anything
                        /*
                        * the fist way I did, yes, much worse, you know alredy, right?
                        * path = path.Trim().Replace(@"\", "/").Replace(" ", @"\ ").Replace("(", @"\(").Replace(")", @"\)"); // taking of the spaces and putting '\' where its needed
                        * path = path.Replace("[", @"\[").Replace("]", @"\]").Replace("{", @"\{").Replace("}", @"}]").Trim('"'); // nor sure if 
                        */
                        #endregion
                        Clipboard.SetText(path); // coping it to the user's clipboard
                        Console.WriteLine
                        (
                        $"\n   The path was translated to:" +
                        $"\n\n   {path}" +
                        $"\n\n   and it is alredy copied to your clipbord."
                        ); // just a bit more of aestheticness, yeah, ..., go on continue throught the code
                    }
                    catch (ArgumentNullException)
                    {
                        Console.Clear();
                        Console.WriteLine("\n   Please inform a non-null value so the translation is possible," +
                            "\n   if you would like to finish the solution, press enter:");
                        Console.Write("\n   "); // same thing as before, just for aesthetics
                        if ((path = Console.ReadLine()) == "")
                        {
                            // didn't want to a valid translation
                            actuallyResetColors(); // Console.ResetColor() isn't all that great on doing its job, so, yeah
                            Console.Write("\n   "); // aesthetic for VS console
                            Environment.Exit(0);
                        }
                        else { repetAfterExcep = true; } // did want to do a valid translation
                    }
                } while (repetAfterExcep); // exception handling loop
                Console.Write
                    (
                    "\n   Type anything and press enter to make another translation,\n" +
                    "   or press enter to finish the solution: "
                    ); // asking for the loop
                if (Console.ReadLine() == "")
                {
                    // didn't want to do another translation
                    actuallyResetColors(); // Console.ResetColor() isn't that great on doing its job, so, yeah
                    Console.Write("\n   "); // aesthetics for VS console
                    Environment.Exit(0);
                }
                // did want to do another translation
                repetTranslation = true;
                Console.Clear();
            } while (repetTranslation); // APL loop
        }
    }
}