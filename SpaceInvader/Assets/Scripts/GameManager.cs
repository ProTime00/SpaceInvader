using Script;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public static GameManager gameManager;
    public Text scoreText;
    

    private void Awake()
    {
        PlayerData save = SaveSystem.LoadSave();
        highScore = save.highScore;
        gameManager = this;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            highScore = 0;
            score = 0;
            SaveSystem.SaveGame(this);
        }
        scoreText.text = score.ToString("D10") + "\n" + highScore.ToString("D10") + "\nHP: " + Player.player.hp;
        if (score > highScore)
        {
            highScore = score;
        }
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SaveGame(this);
    }
}
