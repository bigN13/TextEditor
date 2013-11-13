using ICSharpCode.AvalonEdit.CodeCompletion;

namespace Orchestra.Modules.TextEditorModule.Intellisense
{
    /// <summary>
    /// ICompletionWindowResolver
    /// </summary>
	public interface ICompletionWindowResolver
	{
        /// <summary>
        /// Resolve
        /// </summary>
        /// <returns></returns>
		CompletionWindow Resolve();
	}
}