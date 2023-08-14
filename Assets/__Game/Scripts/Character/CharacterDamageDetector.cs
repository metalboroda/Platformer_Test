using UnityEngine;

namespace Assets.__Game.Scripts.Character
{
  public abstract class CharacterDamageDetector : MonoBehaviour
  {
    [SerializeField] protected LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
      Vector2 triggerPosition = transform.position;
      Vector2 colliderPosition = other.transform.position;

      float xDifference = Mathf.Abs(triggerPosition.x - colliderPosition.x);
      float yDifference = Mathf.Abs(triggerPosition.y - colliderPosition.y);

      if (xDifference > yDifference)
      {
        if (triggerPosition.x < colliderPosition.x || triggerPosition.x > colliderPosition.x)
        {
          SideCollision(other.gameObject);
        }
      }
      else
      {
        if (triggerPosition.y < colliderPosition.y)
        {
          TopCollision(other.gameObject);
        }
        else
        {
          BottomCollision(other.gameObject);
        }
      }
    }

    public virtual void TopCollision(GameObject collidedObject)
    {
    }

    public virtual void BottomCollision(GameObject collidedObject)
    {
    }

    public virtual void SideCollision(GameObject collidedObject)
    {
    }
  }
}