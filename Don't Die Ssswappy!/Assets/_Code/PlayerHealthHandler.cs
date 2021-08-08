using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    public void Crash()
    {
        gameObject.SetActive(false);
    }
}
