namespace DevIn.Extensions.DotNet.Nugets.Models;

public record NugetResponse(
	int TotalHits,
	List<NugetPackageRecord> Data);