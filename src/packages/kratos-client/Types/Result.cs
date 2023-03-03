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

/// <summary>
/// Result of a api call that has an empty result on success
/// </summary>
/// <typeparam name="TError">Type of the error</typeparam>
internal record EmptyResult<TError> : IEmptyResult<TError>
{
    /// <inheritdoc />
    public TError? Error { get; }
    /// <inheritdoc />
    public bool IsSuccess { get; }

    /// <summary>
    /// Creates a success result
    /// </summary>
    public EmptyResult()
    {
        IsSuccess = true;
    }

    /// <summary>
    /// Creates a error result
    /// </summary>
    /// <param name="error">Error object</param>
    public EmptyResult(TError error)
    {
        IsSuccess = false;
        Error = error;
    }
}