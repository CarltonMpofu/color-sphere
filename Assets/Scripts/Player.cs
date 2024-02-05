using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float moveSpeed = 10;

    OrbManager orbManager;
    GamePlay gamePlay;

    float vInput, hInput;


    // Start is called before the first frame update
    void Start()
    {
        orbManager = FindAnyObjectByType<OrbManager>();

        gamePlay = FindObjectOfType<GamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(other.gameObject);
            orbManager.IncreaseCollectedOrbs();
            gamePlay.SetPlayerTargetColor();
        }
    }
}
