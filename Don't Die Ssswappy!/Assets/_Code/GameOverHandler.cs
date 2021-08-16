using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;
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

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);

        continueButton.interactable = false;
    }


    public void ContinueGame()
    {
        scoreHandler.StartTimer();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        deadBoxSpawner.enabled = true;

        gameOverDisplay.gameObject.SetActive(false);
    }
}
