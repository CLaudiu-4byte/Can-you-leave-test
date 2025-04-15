using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Verifică dacă aplicația rulează în editor sau pe un dispozitiv
        #if UNITY_EDITOR
            // Dacă rulează în editor, oprește redarea
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Dacă rulează pe un dispozitiv, închide aplicația
            Application.Quit();
        #endif
    }
}
