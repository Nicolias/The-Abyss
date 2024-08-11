using System.Collections.Generic;
using UnityEngine;

public class AbilityViewFactory : MonoBehaviour
{
    [SerializeField] private AbilityView _abilityView;
    [SerializeField] private Transform _container;

    public List<AbilityView> CreateViews(IEnumerable<ItemModel> models)
    {
        List<AbilityView> views = new List<AbilityView>();

        foreach (var model in models)
        {
            AbilityView newView = Instantiate(_abilityView, _container);
            newView.Initialize(model);
            views.Add(newView);
        }

        return views;
    }
}