using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersPool : MonoBehaviour
{
   [SerializeField] private HoleCollider _holeCollider;
   
   [SerializeField] private List<NumberView> _numbers;
   [SerializeField] private Vector3 _offset;
   
   private Queue<NumberView> _pool;
   
   private void Awake()
   {
      _pool = new Queue<NumberView>(_numbers);
   }

   private void OnEnable()
   {
      _numbers.ForEach(number => number.Disabled += OnNumberDisabled);
      _holeCollider.Detected += OnDetected;
   }

   private void OnDisable()
   {
      _numbers.ForEach(number => number.Disabled -= OnNumberDisabled);
      _holeCollider.Detected += OnDetected;
   }

   private void OnDetected(Cub cub)
   {
      NumberView currentNumber = _pool.Dequeue();
      currentNumber.Show(cub.Position + _offset);
   }

   private void OnNumberDisabled(NumberView number)
   {
      _pool.Enqueue(number);
   }
}
