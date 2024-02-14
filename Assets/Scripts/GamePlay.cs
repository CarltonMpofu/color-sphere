using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject orbParent;

    OrbManager orbManager;

    Player player;

    int playerTargetID;

    bool playGame = false;
    private void Awake() 
    {
        playGame = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        orbManager = FindObjectOfType<OrbManager>();
        player = FindObjectOfType<Player>();

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

        if(playGame)
        { // Pause Game
            playGame = false;
            player.HideJoyStick();
        }
        else
        { // Play game
            playGame = true;
            player.ShowJoyStick();
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
