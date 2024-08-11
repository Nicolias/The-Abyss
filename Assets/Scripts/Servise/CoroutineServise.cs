using System.Collections;
using UnityEngine;

public class CoroutineServise : MonoBehaviour
{
    public Coroutine StartRoutine(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public void StopRoutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }
}
