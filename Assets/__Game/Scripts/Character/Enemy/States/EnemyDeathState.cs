using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Enemy.States
{
  public class EnemyDeathState : State
  {
    public EnemyDeathState(EnemyController enemyController)
    {
      _enemyController = enemyController;
    }

    private readonly EnemyController _enemyController;
    private EnemyHandler _enemyHandler;

    public override void Enter()
    {
      Init();
      _enemyHandler.DestroyCharacter(0);
    }

    private void Init()
    {
      _enemyHandler = _enemyController.EnemyHandler;
    }
  }
}