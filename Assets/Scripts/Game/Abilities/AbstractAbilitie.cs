using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractAbilitie : MonoBehaviour
{
    [SerializeField] private int _duration;

    private Button _button;
    private WaitForSeconds _waitForSeconds;

    private bool _isReady = true;

    protected abstract event Action EffectEnd;

    public int Count { get; private set; }

    public void Initialize(int count)
    {
        Count = count;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _waitForSeconds = new WaitForSeconds(_duration);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UseAbilitie);
        EffectEnd += OnEffectEnd;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(UseAbilitie);
        EffectEnd -= OnEffectEnd;
    }

    protected abstract void Enable();
    protected abstract void Disable();

    private void UseAbilitie()
    {
        if (Count == 0 || _isReady == false)
            return;

        Count--;
        _isReady = false;

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
        _isReady = true;
    }
}
