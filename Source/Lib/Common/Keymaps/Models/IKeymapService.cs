using DevIn.Common.RazorLib.Keys.Models;

namespace DevIn.Common.RazorLib.Keymaps.Models;

public interface IKeymapService
{
	public event Action? KeymapStateChanged;
    
    public KeymapState GetKeymapState();
    
    public void RegisterKeymapLayer(KeymapLayer keymapLayer);
    public void DisposeKeymapLayer(Key<KeymapLayer> keymapLayerKey);
}
