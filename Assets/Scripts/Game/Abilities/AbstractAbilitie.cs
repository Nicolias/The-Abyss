using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAbilitie : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _duration;

    WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_duration);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UseAbilitie);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(UseAbilitie);
    }

    protected abstract void Enable();
    protected abstract void Disable();

    private void UseAbilitie()
    {
        StartCoroutine(StartAbilitie());
    }

    private IEnumerator StartAbilitie()
    {
        Enable();
        yield return _waitForSeconds;
        Disable();
    }
}