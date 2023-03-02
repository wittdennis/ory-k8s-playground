namespace KratosClient.Types;

/// <summary>
/// Result of a api call
/// </summary>
/// <typeparam name="T">Type of the success result</typeparam>
/// <typeparam name="TError">Type of the error result</typeparam>
internal record Result<T, TError> : IResult<T, TError>
{
    /// <inheritdoc />
    public bool IsSuccess { get; }

    /// <inheritdoc />
    public T? Target { get; }

    /// <inheritdoc />
    public TError? Error { get; }

    /// <summary>
    /// Creates a success result
    /// </summary>
    /// <param name="target">Success object</param>
    public Result(T target)
    {
        Target = target;
        IsSuccess = true;
    }

    /// <summary>
    /// Creates a error result
    /// </summary>
    /// <param name="error">Error object</param>
    public Result(TError error)
    {
        Error = error;
        IsSuccess = false;
    }
}