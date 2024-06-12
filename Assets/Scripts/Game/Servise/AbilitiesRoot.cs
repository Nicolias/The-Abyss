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

        _freezeTimeAbilitie.Initialize(abilitiesConfig.FreezeTimeAbilitieCount);
        _scaleAbilitie.Initialize(abilitiesConfig.ScaleAbilitieCount);
        _speedAbilitie.Initialize(abilitiesConfig.SpeedAbilitieCount);
    }
}