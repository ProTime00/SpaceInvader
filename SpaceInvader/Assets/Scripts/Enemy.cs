
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int scoreGiven;
    public GameObject bullet;
    public Transform shottingOffset;
    public int type;
    private AudioSource _audioSource;

    public delegate void DIE();

    public static event DIE IsDead;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (type is 1)
        {
            GetComponent<Renderer>().material.color = Color.red;
            scoreGiven = 100;
            return;
            
        }
        if (type is 2)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            scoreGiven = 500;
            return;
        }
        if (type is 3)
        {
            GetComponent<Renderer>().material.color = Color.green;
            scoreGiven = 1000;
            return;
        }
        if (type is 4)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
            scoreGiven = 5000;
            return;
        }

        throw new InvalidCastException($"type: {type} is wrong");

    }


    private void FixedUpdate()
    {
        int r = Random.Range(1, 1001);
        if (r == 42)
        {
            _audioSource.Play();
            GameObject shot = Instantiate(bullet, shottingOffset.transform.position, Quaternion.identity);
            Destroy(shot, 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name is not "EnemyBullet(Clone)")
        {
            IsDead.Invoke();
            GameManager.gameManager.score += scoreGiven;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
