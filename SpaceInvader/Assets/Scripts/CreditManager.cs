using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{
    public Text credit;
    public int timer = 250;

    private void FixedUpdate()
    {
        if (timer is 0)
        {
            MySceneManager.GoToMenuScene();
        }
        credit.transform.Translate(0, 30, 0,Space.World);
        timer--;
    }
}
