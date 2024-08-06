using System;

public class AbstractItemModel
{
    private SaveLoader _loader;

    public AbstractItemModel(SaveLoader loader, ItemData data)
    {
        if(loader == null)
            throw new ArgumentNullException();

        if(data != null) 
            throw new ArgumentOutOfRangeException();

        _loader = loader;
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