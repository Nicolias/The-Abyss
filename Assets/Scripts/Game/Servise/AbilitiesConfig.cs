using System.Collections.Generic;
using System.Linq;

public class AbilitiesConfig
{
    private SaveLoader _saveLoader;

    private List<AbstractItemModel> _items;

    public int SpeedAbilitieCount { get; private set; }
    public int ScaleAbilitieCount { get; private set; }
    public int FreezeTimeAbilitieCount { get; private set; }

    public AbilitiesConfig(SaveLoader saveLoader)
    {
        _saveLoader = saveLoader;

        _items = new List<AbstractItemModel>()
        {
            new SpeedUpAbilityModel(saveLoader),
            new ScaleUpAbilityModel(saveLoader),
            new FreezeTimeAbilityModel(saveLoader)
        };
    }

    public T GetModel<T>() where T : AbstractItemModel
    {
        return _items.FirstOrDefault(ability => ability is T) as T;
    }
}