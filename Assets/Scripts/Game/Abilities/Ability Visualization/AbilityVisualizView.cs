using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityVisualizView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _loadingImage;
    [SerializeField] private Image _itemImage;

    private AbilityModel _model;

    private Coroutine _coroutine;

    public void Initialize(AbilityModel model)
    {
        if (model == null)
            throw new ArgumentNullException();

        _model = model;
        _text.text = "";
        _itemImage.sprite = model.ItemSprite;
    }

    public void Enable()
    {
        _model.EffectStarted += Show;
        _model.LeftTimeChanged += OnChanged;
        _model.EffectEnd += Hide;
    }

    public void Disable()
    {
        _model.EffectStarted -= Show;
        _model.LeftTimeChanged -= OnChanged;
        _model.EffectEnd -= Hide;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnChanged(int secondsLeft)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _text.text = secondsLeft.ToString();

        _coroutine = StartCoroutine(Fill(secondsLeft));
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Fill(float currentSeconds)
    {
        float currentFillAmoundNormolized = currentSeconds / _model.EffectDuration;

        while (_loadingImage.fillAmount != 0)
        {
            _loadingImage.fillAmount = Mathf.MoveTowards
            (
                _loadingImage.fillAmount,
                currentFillAmoundNormolized,
                (_loadingImage.fillAmount - currentFillAmoundNormolized) * Time.deltaTime
            );

            yield return null;
        }
    }
}
