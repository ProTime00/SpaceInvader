using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyLine1;
    public GameObject EnemyLine2;
    public GameObject EnemyLine3;
    private int _timer = 40 * 50;
    
    private void Start()
    {
        Instantiate(EnemyLine3, transform.position, transform.rotation); 
        Vector3 pos = Vector3.zero;
        pos.y -= 1.5f;
        Instantiate(EnemyLine2, transform.position + pos, transform.rotation);
        pos.y -= 1.5f;
        Instantiate(EnemyLine1, transform.position + pos, transform.rotation);
        
    }

    private void FixedUpdate()
    {
        if (_timer == 0)
        {
            Instantiate(EnemyLine3, transform.position, transform.rotation); 
            Vector3 pos = Vector3.zero;
            pos.y -= 1.5f;
            Instantiate(EnemyLine2, transform.position + pos, transform.rotation);
            pos.y -= 1.5f;
            Instantiate(EnemyLine1, transform.position + pos, transform.rotation);
            _timer = 40 * 50;
            return;
        }

        _timer--;
    }
}
