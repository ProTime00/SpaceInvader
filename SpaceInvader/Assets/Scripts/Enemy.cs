
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int scoreGiven;
    public int type;


    private void Awake()
    {
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

        throw new InvalidCastException($"type: {type} is wrong");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.gameManager.score += scoreGiven;
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
