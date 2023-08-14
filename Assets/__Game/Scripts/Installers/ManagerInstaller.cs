using Assets.__Game.Scripts.Inventory;
using Assets.__Game.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Installers
{
  public class ManagerInstaller : MonoInstaller
  {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CollectibleManager collectibleManager;
    [SerializeField] private InventoryManager inventoryManager;

    public override void InstallBindings()
    {
      Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
      Container.Bind<CollectibleManager>().FromInstance(collectibleManager).AsSingle();
      Container.Bind<InventoryManager>().FromInstance(inventoryManager).AsSingle();
    }
  }
}