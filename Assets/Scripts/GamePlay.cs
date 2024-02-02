using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] GameObject orbParent;

    OrbManager orbManager;

    Player player;

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

    void SetPlayerTargetColor()
    {
        Orb[] orbs = orbParent.GetComponentsInChildren<Orb>();
        
        Orb targetOrb = orbs[Random.Range(0, orbs.Length)];

        Color getTargetColor = orbManager.FindOrbColor(targetOrb.GetOrbColorID());

        player.GetComponent<SpriteRenderer>().color = getTargetColor;
    }

    
}