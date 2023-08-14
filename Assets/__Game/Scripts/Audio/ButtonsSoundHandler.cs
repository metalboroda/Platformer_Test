using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.__Game.Scripts.Audio
{
  public class ButtonsSoundHandler : MonoBehaviour
  {
    [SerializeField] private List<Button> buttons = new();

    [Header("Audio")]
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _selectionSound;

    private readonly List<EventTrigger> _eventTriggers = new();

    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
      InitializeButtonsAndTriggers();
    }

    private void InitializeButtonsAndTriggers()
    {
      foreach (Button button in buttons)
      {
        if (!button.TryGetComponent<EventTrigger>(out var eventTrigger))
          eventTrigger = button.gameObject.AddComponent<EventTrigger>();

        button.onClick.AddListener(PlayButtonClickSound);

        _eventTriggers.Add(eventTrigger);

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.Select };
        entry.callback.AddListener(_ => PlayButtonSelectionSound());
        eventTrigger.triggers.Add(entry);
      }
    }


    private void OnDestroy()
    {
      foreach (Button button in buttons)
      {
        button.onClick.RemoveListener(PlayButtonClickSound);
      }
    }

    private void PlayButtonClickSound()
    {
      if (_clickSound != null)
        _audioSource.PlayOneShot(_clickSound);
    }

    private void PlayButtonSelectionSound()
    {
      if (_selectionSound != null)
        _audioSource.PlayOneShot(_selectionSound);
    }
  }
}