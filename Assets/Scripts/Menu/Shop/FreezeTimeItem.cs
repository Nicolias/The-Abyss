public class FreezeTimeItem : AbstractItemView
{
    protected override AbstractItemModel GetModel(AbilitiesConfig abilitiesConfig)
    {
        return abilitiesConfig.GetModel<FreezeTimeAbilityModel>();
    }
}
