namespace DevIn.Common.RazorLib.Exceptions;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: the 'Exception' datatype is far more common in code,
/// 	than some specific type (example: DialogDisplay.razor).
///     So, adding 'DevIn' in the class name for redundancy seems meaningful here.
/// </remarks>
public class DevInCommonException : DevInException
{
    public DevInCommonException(string? message = null, Exception? innerException = null)
        : base(message, innerException)
    {

    }
}
