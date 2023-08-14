using Assets.__Game.Scripts.Character.Enemy.States;

namespace Assets.__Game.Scripts.Character.Enemy
{
  public class EnemyController : CharacterController
  {
    public EnemyHandler EnemyHandler { get; private set; }
    public EnemyMovement EnemyMovement { get; private set; }
    public EnemyAnimation EnemyAnimation { get; private set; }
    public EnemyAudioHandler EnemyAudioHandler { get; private set; }
    public EnemyDamageDetector EnemyDamageDetector { get; private set; }

    public override void Awake()
    {
      EnemyHandler = GetComponent<EnemyHandler>();
      EnemyMovement = GetComponent<EnemyMovement>();
      EnemyAnimation = GetComponent<EnemyAnimation>();
      EnemyAudioHandler = GetComponent<EnemyAudioHandler>();
      EnemyDamageDetector = GetComponentInChildren<EnemyDamageDetector>();

      base.Awake();

      Init();
    }

    private void Start()
    {
      StateMachineController.ChangeState(new EnemyMovementState(this));
    }

    private void Init()
    {
      EnemyHandler.Init(this);
      EnemyAudioHandler.Init(EnemyHandler);
      EnemyDamageDetector.Init(EnemyHandler);
    }
  }
}