namespace DevIn.Common.RazorLib.Installations.Models;

/// <remarks>
/// This class is an exception to the naming convention, "don't use the word 'DevIn' in class names".
/// 
/// Reason for this exception: when one first starts interacting with this project,
/// 	this type might be one of the first types they interact with. So, the redundancy of namespace
/// 	and type containing 'DevIn' feels reasonable here.
/// </remarks>
public enum DevInHostingKind
{
    ServerSide,
    Wasm,
    Photino,
    UnitTestingSynchronous,
    UnitTestingAsync,
}
