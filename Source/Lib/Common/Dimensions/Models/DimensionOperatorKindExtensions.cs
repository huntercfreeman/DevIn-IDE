using DevIn.Common.RazorLib.Exceptions;

namespace DevIn.Common.RazorLib.Dimensions.Models;

public static class DimensionOperatorKindExtensions
{
    public static string GetStyleString(this DimensionOperatorKind dimensionOperatorKind)
    {
        return dimensionOperatorKind switch
        {
            DimensionOperatorKind.Add => "+",
            DimensionOperatorKind.Subtract => "-",
            DimensionOperatorKind.Multiply => "*",
            DimensionOperatorKind.Divide => "/",
            _ => throw new DevInCommonException($"The {nameof(DimensionOperatorKind)}: '{dimensionOperatorKind}' was not recognized.")
        };
    }
}