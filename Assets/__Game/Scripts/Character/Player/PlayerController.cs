using Assets.__Game.Scripts.Character.Player.States;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerController : CharacterController
  {
    public PlayerHandler PlayerHandler { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }
    public PlayerAudioHandler PlayerAudioHandler { get; private set; }
    public PlayerDamageDetector PlayerDamageDetector { get; private set; }

    public override void Awake()
    {
      PlayerHandler = GetComponent<PlayerHandler>();
      PlayerMovement = GetComponent<PlayerMovement>();
      PlayerAnimation = GetComponent<PlayerAnimation>();
      PlayerAudioHandler = GetComponent<PlayerAudioHandler>();
      PlayerDamageDetector = GetComponentInChildren<PlayerDamageDetector>();

      base.Awake();

      Init();
    }

    private void Start()
    {
      StateMachineController.ChangeState(new PlayerMovementState(this));
    }

    private void Init()
    {
      PlayerHandler.Init(this);
      PlayerMovement.Init(this);
      PlayerAudioHandler.Init(PlayerMovement, PlayerDamageDetector);
      PlayerDamageDetector.Init(PlayerHandler, PlayerMovement);
    }
  }
}