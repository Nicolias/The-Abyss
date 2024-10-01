using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class AbilityVisualizeFactory : MonoBehaviour
{
    [SerializeField] private AbilityVisualizView _template;
    [SerializeField] private Transform _container;

    private List<AbilityVisualizView> _views;

    public void Initialize(IEnumerable<AbilityModel> models)
    {
        _views = new List<AbilityVisualizView>();

        foreach (var model in models)
        {
            AbilityVisualizView view = Instantiate(_template, _container);
            view.Initialize(model);
            
            _views.Add(view);
        }
    }

    public void Enable()
    {
        _views.ForEach(view => view.Enable());
    }

    public void Disable()
    {
        _views.ForEach(_view => _view.Disable());
    }
}