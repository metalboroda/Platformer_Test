using TMPro;
using UnityEngine;

namespace Assets.__Game.Scripts.Managers
{
  public class CollectibleManager : MonoBehaviour
  {
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI collectibleText;

    private int _collectibleCounter;

    public void IncreaseCollectibleCounter()
    {
      _collectibleCounter++;

      DisplayCollectibleCounterText();
    }

    private void DisplayCollectibleCounterText()
    {
      collectibleText.SetText(_collectibleCounter.ToString());
    }
  }
}