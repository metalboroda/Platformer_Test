namespace Assets.__Game.Scripts.Character.Enemy
{
  public class EnemyAnimation : CharacterAnimation
  {
    public override void MovementAnim()
    {
      animator.CrossFadeInFixedTime(animationHash.Movement, crossfadeDuration);
    }

    public override void MovementBlend(float value)
    {
      animator.SetFloat(animationHash.MovementBlend, value);
    }
  }
}