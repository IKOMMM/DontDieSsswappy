using UnityEngine;

public class DeadBoxHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other)
        {
            PlayerHealthHandler playerHealth = other.GetComponent<PlayerHealthHandler>();

            if(playerHealth == null) { return; }

            playerHealth.Crash();
        }
    }
}
