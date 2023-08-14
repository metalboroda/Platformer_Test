using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.__Game.Scripts.Controllers
{
  public class SceneController : MonoBehaviour
  {
    public void ResetartCurrentScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}