namespace FToolkit.Helpers.GitHub;

/// <summary>
/// GitHubリポジトリ関連のヘルパークラスです。
/// </summary>
public static class RepositoryHelper
{
    /// <summary>
    /// オーナー名とリポジトリ名を取得します。
    /// </summary>
    /// <param name="repository">「オーナー名/リポジトリ名」形式の文字列。</param>
    /// <returns>オーナー名とリポジトリ名を返します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="repository"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="repository"/>が空か「オーナー名/リポジトリ名」形式ではありません。</exception>
    public static (string Owner, string RepositoryName) GetRepositoryOwnerAndName(string repository)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);

        return repository.Split('/') is [{ Length: > 0 } repositoryOwner, { Length: > 0 } repositoryName]
            ? (repositoryOwner, repositoryName)
            : throw new ArgumentException("Invalid repository format. Expected format is owner/repo.");
    }
}
