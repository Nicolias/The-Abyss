using System.Collections;
using UnityEngine;

namespace Scripts.Servises
{
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
}