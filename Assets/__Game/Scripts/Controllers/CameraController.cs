using Cinemachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Controllers
{
  public class CameraController : MonoBehaviour
  {
    [SerializeField] private Transform player;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private CinemachineConfiner playerCameraConfiner;
    [SerializeField] public PolygonCollider2D cameraBounds;

    private void Start()
    {
      SetPlayerCamera();
      SetCameraBounds();
    }

    private void SetPlayerCamera()
    {
      playerCamera.Follow = player;
    }

    private void SetCameraBounds()
    {
      playerCameraConfiner.m_BoundingShape2D = cameraBounds;
    }
  }
}