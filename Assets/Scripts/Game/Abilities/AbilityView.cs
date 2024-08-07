using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbilityView : MonoBehaviour
{
    [SerializeField] private TMP_Text _count;

    private Button _button;
    private WaitForSeconds _waitForSeconds;

    private ItemModel _model;

    protected abstract event Action EffectEnd;

    public int Count => _model.Count;

    public void Initialize(ItemModel model)
    {
        _waitForSeconds = new WaitForSeconds(model.Data.EffectDuration);
        _model = model;
        UpdateCounText();
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UseAbilitie);
        EffectEnd += OnEffectEnd;

        if (Count == 0)
            _button.interactable = false;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(UseAbilitie);
        EffectEnd -= OnEffectEnd;
    }

    private void UpdateCounText()
    {
        _count.text = Count.ToString();
    }

    protected abstract void Enable();
    protected abstract void Disable();

    private void UseAbilitie()
    {
        if (Count == 0)
            return;

        _model.Remove();
        _button.interactable = false;
        UpdateCounText();

        StartCoroutine(StartAbilitie());
    }

    private IEnumerator StartAbilitie()
    {
        Enable();
        yield return _waitForSeconds;
        Disable();
    }

    private void OnEffectEnd()
    {
        _button.interactable = Count > 0;
    }
}
