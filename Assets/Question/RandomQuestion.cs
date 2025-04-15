using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class RandomQuestionManager : MonoBehaviour
{   
    [SerializeField] private GameObject panel; 
    [SerializeField] private TextMeshProUGUI questionText;
    [Header("Întrebări")]
    [TextArea(2, 5)]
    [SerializeField] private List<string> questions = new List<string>();
    
    // Păstrează evidența întrebărilor deja afișate pentru a evita repetițiile
    private List<int> usedQuestionIndices = new List<int>();
    
    private void Start()
    {
        // Verifică dacă avem referință către Text
        if (questionText == null)
        {
            Debug.LogError("Nu există referință către componenta Text pentru întrebare!");
            return;
        }
        

        // Afișează prima întrebare la început
        DisplayRandomQuestion();
    }
    
    private void Update()
    {
        // Verifică apăsarea tastei Enter
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DisplayRandomQuestion();
        }
    }
    
    // Metoda pentru a selecta și afișa o întrebare aleatorie
    public void DisplayRandomQuestion()
    {
        if (questions.Count == 0 || questionText == null)
            return;

        // Dacă toate întrebările au fost afișate, resetează
        if (usedQuestionIndices.Count >= questions.Count)
        {
            usedQuestionIndices.Clear();
        }

        // Creează o listă cu indecșii disponibili (nefolosiți)
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < questions.Count; i++)
        {
            if (!usedQuestionIndices.Contains(i))
                availableIndices.Add(i);
        }

        // Alege un index random din lista disponibilă
        int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];

        // Marchează acest index ca fiind folosit
        usedQuestionIndices.Add(randomIndex);

        // Afișează întrebarea
        questionText.text = questions[randomIndex];
    }
}
