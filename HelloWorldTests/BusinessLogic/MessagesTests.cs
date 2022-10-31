using HelloWorldLibrary.BusinessLogic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace HelloWorldTests.BusinessLogic;

public class MessagesTests
{
    /*
     Facts are tests which are always true. They test invariant conditions.
    Theories are tests which are only true for a particular set of data.
     */
    [Fact]
    public void Greeting_InEnglish()
    {
        // Create as Null Logger (MS provided value - with Abstractions) used instead of Mock
        // Mocking the Messages value - ILogger<Messages> log
        // NullLogger --> Eats the logs
        ILogger<Messages> logger = new NullLogger<Messages>();

        Messages messages = new(logger);

        string expected = "Hello World";
        string actual = messages.Greeting("en");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Greeting_InSpanish()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        string expected = "Hola Mundo";
        string actual = messages.Greeting("es");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Greeting_InFrench()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        string expected = "Bonjour le monde";
        string actual = messages.Greeting("fr");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Greeting_Invalid()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        // Test for Expected outcome for bad/wrong data
        Assert.Throws<InvalidOperationException>(() => messages.Greeting("test"));
    }
}
