namespace DevIn.CompilerServices.DotNetSolution.Models.Project;

public interface ISolutionMember
{
	public SolutionMemberKind SolutionMemberKind { get; }
	public Guid ProjectIdGuid { get; }
}
