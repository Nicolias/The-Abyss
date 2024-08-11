using System;
using UnityEngine;

public class AbilitiesRoot : MonoBehaviour
{
    [SerializeField] private AbilityRouter _abilityRouter;

    public void Initialize(AbilitiesConfig abilitiesConfig, CoroutineServise coroutineServise)
    {
        if (abilitiesConfig == null)
            throw new NullReferenceException();

        if (coroutineServise == null)
            throw new NullReferenceException();

        _abilityRouter.Initialize(abilitiesConfig.Items, coroutineServise);
    }

    private void OnEnable()
    {
        _abilityRouter.Enable();
    }

    private void OnDisable()
    {
        _abilityRouter.Disable();
    }
}