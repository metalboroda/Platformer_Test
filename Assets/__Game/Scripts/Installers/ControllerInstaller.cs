using Assets.__Game.Scripts.Controllers;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Installers
{
  public class ControllerInstaller : MonoInstaller
  {
    [SerializeField] private InputController inputController;
    [SerializeField] private UIController uIController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private UISoundController uISoundController;
    [SerializeField] private SceneController sceneController;

    public override void InstallBindings()
    {
      Container.Bind<InputController>().FromInstance(inputController).AsSingle();
      Container.Bind<UIController>().FromInstance(uIController).AsSingle();
      Container.Bind<CameraController>().FromInstance(cameraController).AsSingle();
      Container.Bind<UISoundController>().FromInstance(uISoundController).AsSingle();
      Container.Bind<SceneController>().FromInstance(sceneController).AsSingle();
    }
  }
}