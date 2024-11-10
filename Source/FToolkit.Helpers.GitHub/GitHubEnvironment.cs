namespace FToolkit.Helpers.GitHub;

/// <summary>
/// GitHubの環境変数を取得するためのクラスです。
/// </summary>
public static class GitHubEnvironment
{
    /// <summary>
    /// GITHUB_TOKENを取得します。
    /// </summary>
    /// <returns>環境変数GITHUB_TOKENの値を返します。</returns>
    /// <exception cref="InvalidOperationException">GITHUB_TOKENを取得できませんでした。</exception>
    public static string GetGitHubToken()
    {
        var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");

        return string.IsNullOrEmpty(token)
            ? throw new InvalidOperationException("GITHUB_TOKEN is not set.")
            : token;
    }
}
