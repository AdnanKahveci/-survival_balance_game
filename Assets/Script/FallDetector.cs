using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Oyuncunun tag'inin "Player" oldu�undan emin olun
        if (other.CompareTag("Player"))
        {
            // Ba�lang�� sahnesine d�n
            SceneManager.LoadScene("Level0"); // "StartScene" yerine sizin ba�lang�� sahnenizin ismini yaz�n
        }
    }
}
