using System;

public abstract class AbstractItemModel
{
    private SaveLoader _loader;

    public AbstractItemModel(SaveLoader loader)
    {
        if(loader == null)
            throw new ArgumentNullException();

        _loader = loader;
        Count = loader.LoadOrDefault(Id);
    }

    protected abstract string Id { get; }

    public int Count { get; private set; }
    public abstract int Price { get; }

    public event Action Changed;

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
        _loader.Save(Id, Count);
    }
}

public class SpeedUpAbilityModel : AbstractItemModel
{
    public SpeedUpAbilityModel(SaveLoader loader) : base(loader)
    {
    }

    protected override string Id => nameof(SpeedUpAbilityModel);

    public override int Price => 100;
}

public class FreezeTimeAbilityModel : AbstractItemModel
{
    public FreezeTimeAbilityModel(SaveLoader loader) : base(loader)
    {
    }

    protected override string Id => nameof(FreezeTimeAbilityModel);

    public override int Price => 100;
}

public class ScaleUpAbilityModel : AbstractItemModel
{
    public ScaleUpAbilityModel(SaveLoader loader) : base(loader)
    {
    }

    protected override string Id => nameof(ScaleUpAbilityModel);

    public override int Price => 100;

}