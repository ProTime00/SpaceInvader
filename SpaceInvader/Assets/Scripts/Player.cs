using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  private bool _allowedToShot = true;
  private int _timer = 30;
  private bool _end;
  private AudioSource[] _audioSource;

  private Animator _animator;

  public Transform shottingOffset;
  public static Player player;
  public int hp = 3;

  private void Awake()
  {
    
    _audioSource = GetComponents<AudioSource>();
    _animator = GetComponent<Animator>();
    player = this;
    bullet.name = "Bullet";
  }

  private void EnemyOnIsDead()
  {
    _audioSource[2].Play();
  }

  private void Start()
  {
    Enemy.IsDead += EnemyOnIsDead;
    Bullet.OnDestroyed += BulletOnOnDestroyed;
  }

  private void OnDestroy()
  {
    Enemy.IsDead -= EnemyOnIsDead;
    Bullet.OnDestroyed -= BulletOnOnDestroyed;
  }

  private void BulletOnOnDestroyed()
  {
    _allowedToShot = true;
  }

  // Update is called once per frame
  void Update()
  {
    if (_end)
    {
      if (_timer == 0)
      {
        MySceneManager.GoToCreditsScene();
      }

      _timer--;
      return;
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (!_allowedToShot)
      {
        return;
      }

      _audioSource[0].Play();
      GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
      Destroy(shot, 3f);
      _allowedToShot = false;
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
      _audioSource[1].Play();
      _animator.SetTrigger("die");
      _end = true;
    }
  }
  
}
