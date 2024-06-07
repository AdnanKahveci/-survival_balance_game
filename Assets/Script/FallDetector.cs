using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Oyuncunun tag'inin "Player" olduðundan emin olun
        if (other.CompareTag("Player"))
        {
            // Baþlangýç sahnesine dön
            SceneManager.LoadScene("Level0"); // "StartScene" yerine sizin baþlangýç sahnenizin ismini yazýn
        }
    }
}
