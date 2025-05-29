using System.Reflection;

namespace DevIn.Common.RazorLib.Reflectives.Models;

public record ReflectiveOptions(params Assembly[] AssembliesToScanList);