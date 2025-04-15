using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;     // cât de repede se mișcă
    
    [SerializeField] private GameObject panel; // Reference to the panel GameObject

    [SerializeField ]public Sprite EnterSprite; // Sprite-ul care va fi setat
    private SpriteRenderer spriteRenderer;

    private bool isEnterPressed = false; // Flag to check if Enter was pressed

    [SerializeField] private Sprite ZXSprite; // Sprite-ul care va fi setat

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifică dacă tasta Enter este apăsată
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            if(panel.activeSelf==true && !isEnterPressed) // Check if the panel is active
            {
                isEnterPressed = true; // Set the flag to true
                spriteRenderer.sprite= EnterSprite; // Setează sprite-ul EnterSprite
            }

        }
                            // Verifică dacă tasta Z este apăsată
        if (Input.GetKey(KeyCode.Z))
        {
            
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            spriteRenderer.sprite= ZXSprite; // Setează sprite-ul EnterSprite
            isEnterPressed = false; // Reset the flag when Z is pressed

            // Mișcă obiectul în sus
        }else if (Input.GetKey(KeyCode.X))
        {

            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            spriteRenderer.sprite= ZXSprite; // Setează sprite-ul EnterSprite
            isEnterPressed = false; // Reset the flag when X is pressed

        }
    }


}


