using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerAnimation : CharacterAnimation
  {
    public override void IdleAnim()
    {
      animator.CrossFadeInFixedTime(animationHash.Idle, crossfadeDuration);
    }

    public override void MovementAnim()
    {
      animator.CrossFadeInFixedTime(animationHash.Movement, crossfadeDuration);
    }

    public override void MovementBlend(float value)
    {
      animator.SetFloat(animationHash.MovementBlend, value, dampingTime, Time.deltaTime);
    }

    public override void InAirAnim()
    {
      animator.CrossFadeInFixedTime(animationHash.InAir, crossfadeDuration);
    }

    public override void JumpAnim()
    {
      animator.CrossFadeInFixedTime(animationHash.Jump, crossfadeDuration);
    }
  }
}