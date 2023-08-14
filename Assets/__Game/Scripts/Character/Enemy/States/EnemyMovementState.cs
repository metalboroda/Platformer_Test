using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Enemy.States
{
  public class EnemyMovementState : State
  {
    public EnemyMovementState(EnemyController enemyController)
    {
      _enemyController = enemyController;
    }

    private EnemyController _enemyController;
    private EnemyMovement _enemyMovement;
    private EnemyAnimation _enemyAnimation;

    public override void Enter()
    {
      Init();
      Animation();
    }

    public override void Update()
    {
      AnimationBlend();
    }

    public override void FixedUpdate()
    {
      _enemyMovement.Movement();
    }

    private void Init()
    {
      _enemyMovement = _enemyController.EnemyMovement;
      _enemyAnimation = _enemyController.EnemyAnimation;
    }

    private void Animation()
    {
      _enemyAnimation.MovementAnim();
    }

    private void AnimationBlend()
    {
      _enemyAnimation.MovementBlend(_enemyController.EnemyMovement.Rigidbody.velocity.x);
    }
  }
}