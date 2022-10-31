using HelloWorldLibrary.BusinessLogic;

namespace UltimateHelloWorld
{
    public class App
    {
        private readonly IMessages messages;

        public App(IMessages messages)
        {
            this.messages = messages;
        }

        /// <summary>
        /// Entry point for the Console Application - User created
        /// To execute (specific to this implementation of processing args passed) -
        /// UltimateHelloWorld.exe lang=es
        /// </summary>
        /// <param name="args"></param>
        public void Run(string[] args)
        {
            string lang = "en";

            // For arguments passed at runtime to console
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower().StartsWith("lang="))
                {
                    lang = args[i].Substring(5);
                    break;
                }
            }

            string message = messages.Greeting(lang);
            Console.WriteLine(message);
        }
    }
}
