using UnityEngine;

namespace Assets.__Game.Scripts.Controllers
{
  public class UISoundController : MonoBehaviour
  {
    [Header("Inventory")]
    [SerializeField] private AudioClip openInventory;
    [SerializeField] private AudioClip closeInventory;

    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void OpenInventorySound()
    {
      _audioSource.PlayOneShot(openInventory);
    }

    public void CloseInventorySound()
    {
      _audioSource.PlayOneShot(closeInventory);
    }
  }
}
