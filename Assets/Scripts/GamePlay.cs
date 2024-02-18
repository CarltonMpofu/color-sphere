using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject orbParent;

    OrbManager orbManager;

    Player player;

    GameManager gameManager;

    int playerTargetID;

    bool playGame = true;
    private void Awake() 
    {
        playGame = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        orbManager = FindObjectOfType<OrbManager>();
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        if(!gameManager)
        {
            Debug.LogError("NO GAME MANAGER");
        }

        orbManager.SpawnInitialOrbs();

        SetPlayerTargetColor();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayGame()
    {
        return playGame;
    }

    public void PauseOrUnpauseGame()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log("Pressed");
        Debug.Log(playGame);

        if(playGame)
        { // Pause Game
            playGame = false;
            
            gameManager.PauseGame();
            // player.HideJoyStick();
        }
        else
        { // Play game
            playGame = true;
            // player.ShowJoyStick();
            gameManager.UnPauseGame();
        }
        
    }

    public void SetPlayerTargetColor()
    {
        Orb[] orbs = FindObjectsOfType<Orb>();
        
        Orb targetOrb = orbs[Random.Range(0, orbs.Length)];
        playerTargetID = targetOrb.GetOrbColorID();

        Color getTargetColor = orbManager.FindOrbColor(playerTargetID);

        player.GetComponent<SpriteRenderer>().color = getTargetColor; 
        player.GetComponent<TrailRenderer>().startColor = getTargetColor;
        
    }

    public int GetPlayerTargetID()
    {
        return playerTargetID;
    }

    
}
