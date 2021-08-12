using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreHandler scoreHandler;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private DeadBoxSpawner deadBoxSpawner;

    public void EndGame()
    {
        deadBoxSpawner.enabled = false;

        int finalScore = scoreHandler.EndCounting();
        gameOverText.text = $"Your Sore: {finalScore}";

        gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
