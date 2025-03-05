using System;

namespace Scripts.Gameplay.Abilities
{
    public class AbilityPresenter
    {
        private readonly AbilityModel _model;
        private readonly AbilityView _view;

        public AbilityPresenter(AbilityModel model, AbilityView view)
        {
            if (model == null)
                throw new ArgumentNullException();

            if (view == null)
                throw new ArgumentNullException();

            _model = model;
            _view = view;

            TryEnableView();
        }

        public void Enable()
        {
            _model.Enable();

            _view.Clicked += Onclicked;
            _model.EffectEnd += TryEnableView;
            _model.CountChanged += _view.UpdateCountText;
        }

        public void Disable()
        {
            _model.Disable();

            _view.Clicked -= Onclicked;
            _model.EffectEnd -= TryEnableView;
            _model.CountChanged -= _view.UpdateCountText;
        }

        private void Onclicked()
        {
            _model.PlayEffect();
            _view.Disable();
        }

        private void TryEnableView()
        {
            if (_model.Count > 0)
                _view.Enable();
        }
    }
}