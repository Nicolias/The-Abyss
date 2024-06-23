using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] private Transform _cameraPositionAndRotation;
    [SerializeField] private List<Transform> _cubs;
    [SerializeField] private float _force;
    [SerializeField] private Heart _heart;

    private int[,] _ints = new int[,]
    {
         { 0,0,0,2,2,2,2,2,0,0,0,0,2,2,2,2,2,0,0,0 },
         { 0,0,2,2,1,1,1,2,2,0,0,2,2,1,1,1,2,2,0,0 },
         { 0,2,2,1,1,1,1,1,2,2,2,2,1,1,1,1,1,2,2,0 },
         { 2,2,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,2,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2 },
         { 0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0 },
         { 0,0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,0 },
         { 0,0,0,2,2,1,1,1,1,1,1,1,1,1,1,2,2,0,0,0 },
         { 0,0,0,0,2,2,1,1,1,1,1,1,1,1,2,2,0,0,0,0 },
         { 0,0,0,0,0,2,2,1,1,1,1,1,1,2,2,0,0,0,0,0 },
         { 0,0,0,0,0,0,2,2,1,1,1,1,2,2,0,0,0,0,0,0 },
         { 0,0,0,0,0,0,0,2,2,1,1,2,2,0,0,0,0,0,0,0 },
         { 0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0 },
    };

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        Show();
    }

    public void Show()
    {
        _camera.transform.SetParent(null);

        _camera.transform.position = _cameraPositionAndRotation.position;
        _camera.transform.rotation = _cameraPositionAndRotation.rotation;

        StartCoroutine(ShowQueue());
    }

    private IEnumerator ShowQueue()
    {
        List<Vector3> postions = _heart.GetPositions();

        for (int i = 0; i < _cubs.Count; i++)
        {
            Sequence sequence = DOTween.Sequence();
            _cubs[i].DOJump(postions[i] + new Vector3(0, 0.1f, 0), _force, 1, 3);

            sequence
                .Append(_cubs[i].DOShakeRotation(2, new Vector3(90, 90, 0), 100, 360, true, ShakeRandomnessMode.Harmonic))
                .Append(_cubs[i].DORotate(Vector3.zero, 0))
                .Play();

            if (i % 5 == 0)
                yield return new WaitForSeconds(1f);
        }
    }

    private void A()
    {
        //for (int i = 0; i < _ints.GetLength(0); i++)
        //{
        //    for (int k = 0; k < _ints.GetLength(1); k++)
        //    {
        //        Sequence sequence = DOTween.Sequence();

        //        if (_ints[i, k] == 0)
        //            continue;

        //        if (_ints[i, k] == 2)
        //        {
        //            Rigidbody blacCub = Instantiate(_cubs[1]);
        //            blacCub.transform.position = new Vector3(-k, blacCub.transform.position.y, -i);
        //            continue;
        //        }

        //        Rigidbody cub = Instantiate(_cubs[0]);
        //        cub.transform.position = new Vector3(-k, cub.transform.position.y, -i);

        //        //cub.AddForce(new Vector3(0, 1, 0.3f) * _force);
        //        //cub.transform.DOShakeRotation(3, new Vector3(90,90, 90), 30, 120, true, ShakeRandomnessMode.Harmonic);
        //    }
        //}
    }
}
