// "DI container"
TimeLogger timeLogger = new();
LocationLogger locationLogger = new();

List<ILogger> loggerList = new List<ILogger>();

loggerList.Add(timeLogger);
loggerList.Add(locationLogger);

// App

Manager manager = new(timeLogger);
manager.DoStuff();

Manager otherManager = new(locationLogger);
otherManager.DoStuff();

// Det vi gör med dependency injection är att VI providar alla dependencies UTIFRÅN istället för att skapa dom INUTI

public class Manager
{
    private readonly ILogger _logger;

    public Manager(ILogger logger)
    {
        _logger = logger;
    }

    public void DoStuff()
    {
        // Doing stuff
        Console.WriteLine("Doing stuff...");

        // Use the injected logger to log something
        _logger.Log();
    }
}

public interface ILogger
{
    void Log();
}

public class TimeLogger : ILogger
{
    // Logs how long time something took

    public void Log()
    {
        Console.WriteLine("Logging time...");
    }
}

public class LocationLogger : ILogger
{
    // Logs the location of the user

    public void Log()
    {
        Console.WriteLine("Logging location...");
    }
}