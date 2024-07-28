public class SpeedItem : AbstractItemView
{
    protected override AbstractItemModel GetModel(AbilitiesConfig abilitiesConfig)
    {
        return abilitiesConfig.GetModel<SpeedUpAbilityModel>();
    }
}