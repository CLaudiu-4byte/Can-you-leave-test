using UnityEngine;
using UnityEngine.UI;   // Importing UnityEngine.UI for UI components
using TMPro; // Importing TMPro for TextMeshPro components

public class EnterPress : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private RandomQuestionManager questionManager; // Reference to the RandomQuestionManager script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Panel nu este setat în Inspector!");
        }   

        if (panel != null)
        {
            panel.SetActive(false); // Ensure the panel is initially inactive
        }

        if(questionManager == null)
        {
           questionManager=GetComponent<RandomQuestionManager>(); // Get the RandomQuestionManager component attached to the same GameObject

           if(questionManager ==null)
              {
                Debug.LogError("RandomQuestionManager component not found on the GameObject!"); // Log an error if the component is not found
              }
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) // Check if the Enter key is pressed
        {
            ShowPanelWithRandomWuestion(); // Call the method to show the panel with a random question

        }
    }

    private  void ShowPanelWithRandomWuestion()
    {
        if(questionManager  != null)
        {
            questionManager.DisplayRandomQuestion(); // Call the method to display a random question
        }
        else
        {
            Debug.LogError("RandomQuestionManager is not assigned!"); // Log an error if the component is not assigned
        }

        if(panel != null && !panel.activeSelf) // Check if the panel is not already active
        {
            panel.SetActive(true); // Show the panel
        }
    }
}
