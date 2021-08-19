using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    [SerializeField] AudioSource deadSound;
    [SerializeField] ParticleSystem deadParticles;
    [SerializeField] GameObject ssswappyObj;



    public void Crash()
    {
        gameOverHandler.EndGame();

        ssswappyObj.SetActive(false);
        deadSound.Play();
        deadParticles.Play();

        Invoke(nameof(TurnOffPlayer), 0.25f);             
    }    

    void TurnOffPlayer()
    {
        ssswappyObj.SetActive(true);
        gameObject.SetActive(false);

    }
}
