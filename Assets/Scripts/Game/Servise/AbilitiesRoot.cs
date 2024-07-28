using System;
using UnityEngine;

public class AbilitiesRoot : MonoBehaviour
{
    [SerializeField] private FreezeTimeAbilitie _freezeTimeAbilitie;
    [SerializeField] private ScaleAbilitie _scaleAbilitie;
    [SerializeField] private SpeedAbilitie _speedAbilitie;

    public void Initialize(AbilitiesConfig abilitiesConfig)
    {
        if (abilitiesConfig == null)
            throw new NullReferenceException();

        _freezeTimeAbilitie.Initialize(abilitiesConfig.GetModel<FreezeTimeAbilityModel>());
        _scaleAbilitie.Initialize(abilitiesConfig.GetModel<ScaleUpAbilityModel>());
        _speedAbilitie.Initialize(abilitiesConfig.GetModel<SpeedUpAbilityModel>());
    }
}