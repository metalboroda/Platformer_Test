using Assets.__Game.Scripts.Managers;
using Assets.__Game.Scripts.Managers.GameManagerStates;
using Assets.__Game.Scripts.StateMachine;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Controllers
{
  [RequireComponent(typeof(AudioSource))]
  public class MusicController : MonoBehaviour
  {
    [SerializeField] private AudioClip[] musicTracks;
    [SerializeField] private AudioClip[] loseTracks;
    [SerializeField] private float loseMusicDelay = 1f;

    private int _currentTrackIndex = -1;

    private AudioSource _audioSource;

    [Inject] private GameManager _gameManager;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();

      _gameManager.StateMachineController.OnStateUpdated += Lose;
    }

    private void Start()
    {
      PlayRandomTrack();
    }

    private void OnDestroy()
    {
      _gameManager.StateMachineController.OnStateUpdated -= Lose;
    }

    private void PlayRandomTrack()
    {
      _audioSource.loop = false;

      if (musicTracks.Length > 0)
      {
        int randomIndex = Random.Range(0, musicTracks.Length);

        if (randomIndex == _currentTrackIndex)
        {
          // Play a different track if the same track is selected
          randomIndex = (randomIndex + 1) % musicTracks.Length;
        }

        _currentTrackIndex = randomIndex;
        AudioClip randomClip = musicTracks[_currentTrackIndex];
        _audioSource.clip = randomClip;

        _audioSource.Play();

        StartCoroutine(PlayNextRandomTrackAfterDelay(randomClip.length));
      }
    }

    private IEnumerator PlayNextRandomTrackAfterDelay(float delay)
    {
      yield return new WaitForSeconds(delay);

      PlayRandomTrack();
    }

    private void Lose(State state)
    {
      if (state is GameLoseState)
      {
        _audioSource.Stop();

        StartCoroutine(LoseMusicRoutine());
      }
    }

    private IEnumerator LoseMusicRoutine()
    {
      yield return new WaitForSeconds(loseMusicDelay);

      var randTrack = Random.Range(0, loseTracks.Length);

      _audioSource.clip = loseTracks[randTrack];

      _audioSource.Play();
    }
  }
}