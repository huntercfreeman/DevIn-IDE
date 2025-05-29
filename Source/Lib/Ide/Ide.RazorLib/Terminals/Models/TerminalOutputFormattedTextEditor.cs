using DevIn.TextEditor.RazorLib.Lexers.Models;
using DevIn.Extensions.CompilerServices.Syntax;

namespace DevIn.Ide.RazorLib.Terminals.Models;

public class TerminalOutputFormattedTextEditor : ITerminalOutputFormatted
{
	public TerminalOutputFormattedTextEditor(
		string text,
		List<TerminalCommandParsed> parsedCommandList,
		List<TextEditorTextSpan> textSpanList,
		List<Symbol> symbolList)
	{
		Text = text;
		ParsedCommandList = parsedCommandList;
		TextSpanList = textSpanList;
		SymbolList = symbolList;
	}

	public string Text { get; }
	public List<TerminalCommandParsed> ParsedCommandList { get; }
	public List<TextEditorTextSpan> TextSpanList { get; }
	public List<Symbol> SymbolList { get; }
}
