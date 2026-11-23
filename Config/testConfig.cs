using DotNetEnv;
 
namespace PlaywrightTests.Config;
 
public static class TestConfig
{
    public static string EnvName { get; }
 
    static TestConfig()
    {
        EnvName = Environment.GetEnvironmentVariable("TEST_ENV") ?? "prod";

        Env.NoClobber().TraversePath().Load($".env.{EnvName}");
    }
 
    public static string BaseUrl => Get("BASE_URL");
    public static string UserEmail => Get("TEST_USER_EMAIL");
    public static string UserPassword => Get("TEST_USER_PASSWORD");
 
    private static string Get(string key) =>
        Environment.GetEnvironmentVariable(key)
        ?? throw new InvalidOperationException(
            $"Змінна '{key}' не  '{EnvName}'. Пее .env.{EnvName}");
}