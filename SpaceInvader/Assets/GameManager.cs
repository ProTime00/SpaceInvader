using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager gameManager;

    private void Awake()
    {
        gameManager = this;
    }
}
