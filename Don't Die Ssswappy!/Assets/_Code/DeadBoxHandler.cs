using UnityEngine;

public class DeadBoxHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            PlayerHealthHandler playerHealth = other.GetComponent<PlayerHealthHandler>();

            if (playerHealth == null) { return; }

            playerHealth.Crash();
        }
    }

    private void Update()
    {
        Invoke(nameof(DestroyAfterMoment),10f);
    }

    void DestroyAfterMoment()
    {
        Destroy(gameObject);
    }

    //Other Solution
    /*           
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
    */
}
