namespace KratosClient.Types;

/// <summary>
/// Result of a api call
/// </summary>
/// <typeparam name="T">Type of the success result</typeparam>
/// <typeparam name="TError">Type of the error result</typeparam>
public interface IResult<T, TError>
{
    /// <summary>
    /// Success result of the api call. Null if <see cref="IsSuccess" /> is false.
    /// </summary>
    T? Target { get; }

    /// <summary>
    /// Error result of the api call. Null if <see cref="IsSuccess" /> is true.
    /// </summary>
    TError? Error { get; }

    /// <summary>
    /// Flag indicating if the api call was successfull or not.
    /// </summary>
    bool IsSuccess { get; }
}

/// <summary>
/// Result of a api call that has an empty result on success
/// </summary>
/// <typeparam name="TError">Type of the error</typeparam>
public interface IEmptyResult<TError>
{
    /// <summary>
    /// Error result of the api call. Null if <see cref="IsSuccess" /> is true.
    /// </summary>
    TError? Error { get; }

    /// <summary>
    /// Flag indicating if the api call was successfull or not.
    /// </summary>
    bool IsSuccess { get; }
}