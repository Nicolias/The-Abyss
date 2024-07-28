public class ScaleItem : AbstractItemView
{
    protected override AbstractItemModel GetModel(AbilitiesConfig abilitiesConfig)
    {
        return abilitiesConfig.GetModel<ScaleUpAbilityModel>();
    }
}
