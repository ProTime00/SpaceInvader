using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public float speed = 5;

  public delegate void Destroyed();

  public static event Destroyed OnDestroyed;
    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      if (gameObject.name is "Bullet(Clone)")
      {
        myRigidbody2D.velocity = Vector2.up * speed;
        return;
      }
      myRigidbody2D.velocity = Vector2.down * speed * 1.5f;
       
    }

    private void OnDestroy()
    {
      if (gameObject.name is "Bullet(Clone)")
      {
        OnDestroyed?.Invoke();
      }
    }
}
