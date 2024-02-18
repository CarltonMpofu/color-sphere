using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float moveSpeed = 10;

    OrbManager orbManager;
    GamePlay gamePlay;

    SoundManager soundManager;

    GameManager gameManager;

    float vInput, hInput;


    // Start is called before the first frame update
    void Start()
    {
        orbManager = FindAnyObjectByType<OrbManager>();

        gamePlay = FindObjectOfType<GamePlay>();

        soundManager = FindObjectOfType<SoundManager>();

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideJoyStick()
    {
        joystick.enabled = false;
    }

    public void ShowJoyStick()
    {
        joystick.enabled = true;
    }

    public void UpdatePlayerSpeed()
    {
        moveSpeed += 0.005f;
    }

    private void FixedUpdate() 
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Orb"))
        {
            Orb currentOrb = other.gameObject.GetComponent<Orb>();
            if(currentOrb.GetOrbColorID() == gamePlay.GetPlayerTargetID())
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
                soundManager.PlaySound();
                currentOrb.PlayParticle();
                
                orbManager.IncreaseCollectedOrbs();
                gamePlay.SetPlayerTargetColor();
            }
            else
            { // Got to game over scene
                gameManager.ShowGameOverCanvas();
            }
            
        }
    }
}
