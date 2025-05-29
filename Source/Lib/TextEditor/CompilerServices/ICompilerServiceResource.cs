using DevIn.TextEditor.RazorLib.Lexers.Models;

namespace DevIn.TextEditor.RazorLib.CompilerServices;

public interface ICompilerServiceResource
{
	public ResourceUri ResourceUri { get; }
	public ICompilerService CompilerService { get; }
	public ICompilationUnit CompilationUnit { get; set; }
}
