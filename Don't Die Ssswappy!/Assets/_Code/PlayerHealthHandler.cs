using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;

    public void Crash()
    {
        gameOverHandler.EndGame();

        gameObject.SetActive(false);
    }
}
