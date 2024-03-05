using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
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
}
