using System;
using System.Collections.Generic;

public class AbilitiesConfig
{
    private readonly List<ItemModel> _itemsModel;

    public IEnumerable<ItemModel> Items => _itemsModel;

    public AbilitiesConfig(SaveLoader saveLoader, List<ItemData> itemsData)
    {
        if (saveLoader == null)
            throw new NullReferenceException();

        if (itemsData == null)
            throw new NullReferenceException();

        foreach (var item in itemsData)
        {
            if (item == null)
                throw new NullReferenceException();
        }

        _itemsModel = new List<ItemModel>();

        for (int i = 0; i < itemsData.Count; i++)
        {
            ItemModel newItem = new ItemModel(saveLoader, itemsData[i]);

            newItem.Enable();
            _itemsModel.Add(newItem);
        }
    }
}