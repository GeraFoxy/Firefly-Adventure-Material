using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Исправлено на OnTriggerEnter2D
    {

        if (other.CompareTag("WinPoint"))
        {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
            
        }
    }
}
