namespace FToolkit.Helpers.GitHub.Actions;

/// <summary>
/// GitHub Actions関連のコマンドです。
/// </summary>
public static class ActionsCommand
{
    /// <summary>
    /// グループを開始します。
    /// </summary>
    /// <param name="title">タイトル</param>
    /// <returns>グループを終了するための<see cref="IDisposable"/>オブジェクトを返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="title"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="title"/>が空です。</exception>
    public static IDisposable BeginGroup(string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        return new GitHubActionsGroupDisposable(title);
    }

    static void Group(string title) => Console.WriteLine($"::group::{title}");

    static void EndGroup() => Console.WriteLine("::endgroup::");

    struct GitHubActionsGroupDisposable : IDisposable
    {
        public GitHubActionsGroupDisposable(string title) => Group(title);

        /// <inheritdoc/>
        public readonly void Dispose() => EndGroup();
    }
}
