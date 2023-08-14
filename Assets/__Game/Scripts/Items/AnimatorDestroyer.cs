using Lean.Pool;
using System.Collections;
using UnityEngine;

namespace Assets.__Game.Scripts.Items
{
  public class AnimatorDestroyer : MonoBehaviour
  {
    [SerializeField] private bool isPoolable;

    private Animator _animator;

    private void Awake()
    {
      _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
      StartCoroutine(WaitForAnimationToEnd());
    }

    private IEnumerator WaitForAnimationToEnd()
    {
      while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
      {
        yield return null;
      }

      if (isPoolable)
        LeanPool.Despawn(gameObject);
      else
        Destroy(gameObject);
    }
  }
}
