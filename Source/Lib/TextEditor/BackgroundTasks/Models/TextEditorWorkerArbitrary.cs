using System.Collections.Concurrent;
using DevIn.Common.RazorLib.BackgroundTasks.Models;
using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.TextEditor.RazorLib.BackgroundTasks.Models;

public class TextEditorWorkerArbitrary : IBackgroundTaskGroup
{
	private readonly TextEditorService _textEditorService;
	
	public TextEditorWorkerArbitrary(TextEditorService textEditorService)
	{
		_textEditorService = textEditorService;
	}
	
	public Key<IBackgroundTaskGroup> BackgroundTaskKey { get; } = Key<IBackgroundTaskGroup>.NewKey();
    
    public bool __TaskCompletionSourceWasCreated { get; set; }
    
    public ConcurrentQueue<UniqueTextEditorWork> UniqueTextEditorWorkQueue { get; } = new();
	
	public void PostUnique(
        Func<TextEditorEditContext, ValueTask> textEditorFunc)
    {
    	EnqueueUniqueTextEditorWork(
    		new UniqueTextEditorWork(
	            _textEditorService,
	            textEditorFunc));
    }
	
	public void EnqueueUniqueTextEditorWork(UniqueTextEditorWork uniqueTextEditorWork)
	{
		UniqueTextEditorWorkQueue.Enqueue(uniqueTextEditorWork);
		_textEditorService.BackgroundTaskService.Continuous_EnqueueGroup(this);
	}
	
	public ValueTask HandleEvent()
	{
		if (!UniqueTextEditorWorkQueue.TryDequeue(out UniqueTextEditorWork uniqueTextEditorWork))
			return ValueTask.CompletedTask;
		
		return uniqueTextEditorWork.HandleEvent();
	}
}

