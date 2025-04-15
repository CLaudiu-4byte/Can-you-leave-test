using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextQuestion : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Reference to the panel GameObject
    
    public int counterZKey = 0; // Counter for Z key presses
    public int counterXKey = 0; // Counter for X key presses
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(panel.activeSelf) // Check if the panel is active
        {
            if (Input.GetKeyDown(KeyCode.Z)) // Check if the Z key is pressed
            {
                counterZKey++; // Increment the Z key counter
                Debug.Log("Z key pressed " + counterZKey + " times."); // Log the number of Z key presses
                panel.SetActive(false); // Hide the panel
            // Call the method to display a random question (assuming you have a method for this)
            }
            else if (Input.GetKeyDown(KeyCode.X)) // Check if the X key is pressed
            {
                counterXKey++; // Increment the X key counter
                Debug.Log("X key pressed " + counterXKey + " times."); // Log the number of X key presses
                panel.SetActive(false); // Hide the panel
                // Call the method to display a random question (assuming you have a method for this)
            }
        }


        if(counterZKey-counterXKey==10)
        {
            SceneManager.LoadScene(2); // Load the scene named "EndingA"
        }
        else if(counterXKey-counterZKey==10)
        {
            SceneManager.LoadScene(3); // Load the scene named "EndingB"
        }
        else if(counterZKey+counterXKey==100)
        {
            SceneManager.LoadScene(4); // Load the scene named "Secret"
        }
    }
}
