using System;
using System.Collections.Generic;
using Scripts.Gameplay.Abilities.Visualization;
using Scripts.Menu.ShopSystem.Items;
using Scripts.Servises;
using UnityEngine;

namespace Scripts.Gameplay.Abilities
{
    public class AbilityRouter : MonoBehaviour
    {
        [SerializeField] private AbilityViewFactory _viewFactory;
        [SerializeField] private AbilityVisualizeFactory _visualizeFactory;

        [SerializeField] private AbilityStarter _starter;
        [SerializeField] private AbilityFinisher _finisher;

        private readonly List<AbilityPresenter> _presenters = new List<AbilityPresenter>();

        public void Initialize(IEnumerable<ItemModel> itemModels, CoroutineServise coroutineServise)
        {
            if (itemModels == null)
                throw new ArgumentNullException();

            foreach (ItemModel model in itemModels)
            {
                if (model == null)
                    throw new ArgumentNullException();
            }

            List<AbilityView> views = _viewFactory.CreateViews(itemModels);
            List<AbilityModel> models = CreatModels(itemModels, coroutineServise);

            for (int i = 0; i < models.Count; i++)
                _presenters.Add(new AbilityPresenter(models[i], views[i]));

            _visualizeFactory.Initialize(models);
        }

        public void Enable()
        {
            _presenters.ForEach(presenter => presenter.Enable());
            _visualizeFactory.Enable();
        }

        public void Disable()
        {
            _presenters.ForEach(presenter => presenter.Disable());
            _visualizeFactory.Disable();
        }

        private List<AbilityModel> CreatModels(IEnumerable<ItemModel> itemModels, CoroutineServise coroutineServise)
        {
            List<AbilityModel> models = new List<AbilityModel>();

            foreach (ItemModel itemModel in itemModels)
            {
                AbilityModel newModel = new AbilityModel(_starter, _finisher, itemModel, coroutineServise);
                models.Add(newModel);
            }

            return models;
        }
    }
}