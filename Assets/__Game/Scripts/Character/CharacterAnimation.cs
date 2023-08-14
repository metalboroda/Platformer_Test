using Assets.__Game.Scripts.Animation;
using UnityEngine;

namespace Assets.__Game.Scripts.Character
{
  public abstract class CharacterAnimation : MonoBehaviour
  {
    [SerializeField] protected AnimationHashSO animationHash;

    [Header("Animation param's")]
    [SerializeField] protected float crossfadeDuration = 0.01f;
    [SerializeField] protected float dampingTime = 0.01f;

    protected Animator animator;

    private void Awake()
    {
      animator = GetComponentInChildren<Animator>();
    }

    public virtual void IdleAnim() { }

    public virtual void MovementAnim() { }

    public virtual void MovementBlend(float value) { }

    public virtual void InAirAnim() { }

    public virtual void JumpAnim() { }

    public virtual void DeathAnim() { }
  }
}