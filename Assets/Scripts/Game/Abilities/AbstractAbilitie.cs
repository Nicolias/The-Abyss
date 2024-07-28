using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractAbilitie : MonoBehaviour
{
    [SerializeField] private int _duration;
    [SerializeField] private TMP_Text _count;

    private Button _button;
    private WaitForSeconds _waitForSeconds;

    protected abstract AbstractItemModel Model { get; set; }

    protected abstract event Action EffectEnd;

    public int Count => Model.Count;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _waitForSeconds = new WaitForSeconds(_duration);
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

    protected void OnInitialized()
    {
        _count.text = Model.Count.ToString();
    }

    protected abstract void Enable();
    protected abstract void Disable();

    private void UseAbilitie()
    {
        if (Count == 0 || _button.interactable == false)
            return;

        Model.Remove();
        _button.interactable = false;
        _count.text = Count.ToString();

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
