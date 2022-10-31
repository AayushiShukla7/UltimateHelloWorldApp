using HelloWorldLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json; //Different than NewtonSoft (newer)

namespace HelloWorldLibrary.BusinessLogic
{
    public class Messages : IMessages
    {
        private readonly ILogger<Messages> _log;

        public Messages(ILogger<Messages> log)
        {
            _log = log;
        }

        //Public helper method
        public string Greeting(string language)
        {
            string output = LookupCustomText("Greeting", language);
            // Overkill - But also valid! --> LookupCustomText(nameof(Greeting), language); 
            return output;
        }

        private string LookupCustomText(string key, string language)
        {
            //This fixes the Camelcase(JSON) vs PascalCase(C#) dillema
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                List<CustomText>? messageSets = JsonSerializer
                .Deserialize<List<CustomText>>
                (
                    File.ReadAllText("CustomText.json"), options
                );

                CustomText? messages = messageSets?.Where(x => x.Language == language).First();

                if (messages is null)
                {
                    throw new NullReferenceException("The specified language was not found in the json file.");
                }

                return messages.Translation[key];
            }
            catch (Exception ex)
            {
                _log.LogError("Error looking up the custom text", ex);
                throw;  //Propogate the exception to the parent
            }
        }
    }
}
