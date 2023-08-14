using Assets.__Game.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Installers
{
  public class PrefabInstaller : MonoInstaller
  {
    public GameObject enemyBunnyPrefab;

    public override void InstallBindings()
    {
      Container.BindFactory<Transform, PrefabFactory>().FromComponentInNewPrefab(enemyBunnyPrefab);
    }
  }
}