using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderCondition : MonoBehaviour
{    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="EndingA")
        {
            SceneManager.LoadScene(3); // Load the scene named EndingWiz
        }
        else if(other.tag=="EndingB")
        {
            SceneManager.LoadScene(2); // Load the scene named EndingBarb
        }
        else if(other.tag=="Secret")
        {
            SceneManager.LoadScene(4); // Load the scene named "Secret"
        }
    }

}
