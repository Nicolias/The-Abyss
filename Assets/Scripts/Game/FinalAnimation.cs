using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;
using System;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] private Transform _cameraPositionAndRotation;
    [SerializeField] private Heart _heartMap;

    [SerializeField] private Transform _startCubPosition;
    [SerializeField] private float _force;
    [SerializeField] private float _animationDuration;

    [SerializeField] private Image _keepGoingImage;
    [SerializeField] private Canvas _canvas;

    private List<Transform> _cubs;

    private Camera _camera;

    public event Action Complete;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Show(IEnumerable<Cub> cubs)
    {
        _cubs = new List<Transform>();
        _camera.transform.SetParent(null);

        foreach (var cub in cubs)
        {
            Transform cubTransform = cub.transform;
            _cubs.Add(cubTransform);
            cubTransform.position = _startCubPosition.position;
        }

        _camera.transform.position = _cameraPositionAndRotation.position;
        _camera.transform.rotation = _cameraPositionAndRotation.rotation;

        _keepGoingImage.gameObject.SetActive(true);
        _keepGoingImage.transform.localPosition = new Vector3(_canvas.pixelRect.max.x, 0, 0);

        StartCoroutine(ShowQueue());
    }

    private IEnumerator ShowQueue()
    {
        List<Vector3> postions = _heartMap.GetPositions();

        for (int i = 0; i < _cubs.Count; i++)
        {
            _cubs[i].DOJump(postions[i] + new Vector3(0, 0.1f, 0), _force, 1, _animationDuration);
            _cubs[i].DORotate(new Vector3(0, 360 * 10, 360 * 10), _animationDuration, RotateMode.FastBeyond360);
            _cubs[i].DORotate(Vector3.zero, 0);

            if (i != 0 && i % 5 == 0)
                yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(_animationDuration);

        yield return _keepGoingImage.transform.DOLocalMove(new Vector3(0, 0, 0), _animationDuration / 2).WaitForCompletion();

        Complete?.Invoke();
    }
}
