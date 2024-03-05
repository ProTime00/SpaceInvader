using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;
  public static Player player;
  public int hp = 3;

  private void Awake()
  {
    player = this;
    bullet.name = "Bullet";
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
      Destroy(shot, 10f);
    }

    if (Input.GetKey(KeyCode.LeftArrow))
    {
      var vector3 = Vector3.zero;
      vector3.x = -0.15f;
      transform.position += vector3;
    }
    
    if (Input.GetKey(KeyCode.RightArrow))
    {
      var vector3 = Vector3.zero;
      vector3.x = 0.15f;
      transform.position += vector3;
    }

    if (transform.position.x < -14)
    {
      var vector3 = transform.position;
      vector3.x = -14;
      transform.position = vector3;
    }

    if (transform.position.x > 14)
    {
      var vector3 = transform.position;
      vector3.x = 14;
      transform.position = vector3;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Destroy(other.gameObject);
    hp -= 1;
    if (hp == 0)
    {
      Destroy(gameObject);
    }
  }
}
