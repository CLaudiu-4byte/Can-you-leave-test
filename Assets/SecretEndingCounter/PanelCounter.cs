using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelFadeManager : MonoBehaviour
{
    [SerializeField] private GameObject panelToShow;
    [SerializeField] private float delayBeforeFade = 3f;
    [SerializeField] private float fadeInDuration = 1.5f;
    
    private CanvasGroup canvasGroup;
    
    private void Start()
    {
        // Verifică dacă există referința către panel
        if (panelToShow == null)
        {
            Debug.LogError("Panel-ul nu a fost setat în Inspector!");
            return;
        }
        
        // Obține sau adaugă componenta CanvasGroup pentru controlul transparenței
        canvasGroup = panelToShow.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = panelToShow.AddComponent<CanvasGroup>();
        }
        
        // Inițial, panelul este complet transparent
        canvasGroup.alpha = 0f;
        
        // Asigură-te că panelul este activ pentru a putea fi vizibil după fade
        panelToShow.SetActive(true);
        
        // Pornește corutina pentru afișarea cu întârziere și fade
        StartCoroutine(ShowPanelWithFade());
    }
    
    private IEnumerator ShowPanelWithFade()
    {
        // Așteaptă perioada specificată
        yield return new WaitForSeconds(delayBeforeFade);
        
        // Pornește efectul de fade
        float elapsedTime = 0f;
        
        while (elapsedTime < fadeInDuration)
        {
            // Calculează valoarea alpha în funcție de timpul scurs
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            
            // Incrementează timpul scurs
            elapsedTime += Time.deltaTime;
            
            // Așteaptă până la următorul frame
            yield return null;
        }
        
        // Asigură-te că alpha este exact 1 la final
        canvasGroup.alpha = 1f;
        
        Debug.Log("Panel-ul a apărut cu efect de fade după " + delayBeforeFade + " secunde");
    }
}