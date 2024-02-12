using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject orbParent;

    OrbManager orbManager;

    Player player;

    int playerTargetID;

    // Start is called before the first frame update
    void Start()
    {
        orbManager = FindAnyObjectByType<OrbManager>();
        player = FindAnyObjectByType<Player>();

        orbManager.SpawnInitialOrbs();

        SetPlayerTargetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerTargetColor()
    {
        Orb[] orbs = FindObjectsOfType<Orb>();
        
        Orb targetOrb = orbs[Random.Range(0, orbs.Length)];
        playerTargetID = targetOrb.GetOrbColorID();

        Color getTargetColor = orbManager.FindOrbColor(playerTargetID);

        player.GetComponent<SpriteRenderer>().color = getTargetColor; 
        
    }

    public int GetPlayerTargetID()
    {
        return playerTargetID;
    }

    
}
