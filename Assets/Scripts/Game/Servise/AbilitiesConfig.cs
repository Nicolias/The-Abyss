using System.Collections.Generic;

public class AbilitiesConfig
{
    private SaveLoader _saveLoader;

    private List<AbstractItemModel> _items;

    public IEnumerable<AbstractItemModel> Items => _items;

    public AbilitiesConfig(SaveLoader saveLoader, List<ItemData> items)
    {
        _saveLoader = saveLoader;
        _items = new List<AbstractItemModel>();

        for (int i = 0; i < items.Count; i++)
        {
            _items.Add(new AbstractItemModel(saveLoader, items[i]));
        }
    }
}