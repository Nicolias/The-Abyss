using System;

public class ItemModel
{
    private SaveLoader _loader;

    public ItemModel(SaveLoader loader, ItemData data)
    {
        if(loader == null)
            throw new NullReferenceException();

        if(data == null) 
            throw new NullReferenceException();

        _loader = loader;
        Data = data;
    }

    public int Count { get; private set; }
    public ItemData Data { get; private set; }

    public event Action Changed;

    public void Enable()
    {
        Count = _loader.LoadOrDefault(Data.ID);
    }

    public void Add()
    {
        Count++;

        Changed?.Invoke();
        Save();
    }

    public void Remove()
    {
        if (Count == 0)
            throw new InvalidOperationException();

        Count--;
        Changed?.Invoke();
        Save();
    }

    private void Save()
    {
        _loader.Save(Data.ID, Count);
    }
}