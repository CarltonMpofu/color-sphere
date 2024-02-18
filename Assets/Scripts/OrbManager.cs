using UnityEngine;
using TMPro;

public class OrbManager : MonoBehaviour
{
    // Orb properties
    [Header("Orb Properties")]
    [SerializeField] Orb orbPrefab;
    [SerializeField] int maxOrbs = 5;
    [SerializeField] int orbsToAdd = 5;
    
    [SerializeField] OrbColorSO[] orbColors;

    // Spawning variables
    [Header("Spawning Variables")]
    [SerializeField] float respawnTimer = 0f;
    [SerializeField] float respawnDelay = 3f; // Delay between orb spawns
    [SerializeField] Transform orbsParent;


    [Header("Boundaries")]
    [SerializeField] Transform xPos;
    [SerializeField] Transform yPos;
    [SerializeField] float boundaryOffset = 0.5f;


    [SerializeField] TextMeshProUGUI orbCountsText;
    [SerializeField] TextMeshProUGUI scoreText;

    // Collected orbs count
    int collectedOrbs = 0;

    int score = 0;

    bool initialOrbsSpawned = false;

    Player player;
    GamePlay gamePlay;

    void Start()
    {
        player = FindObjectOfType<Player>();
        gamePlay = FindObjectOfType<GamePlay>();
    }

    void Update()
    {
        if(gamePlay.PlayGame())
        {
            if(initialOrbsSpawned)
            {
                // Update respawn timer
                respawnTimer += Time.deltaTime;

                // Check if we can spawn a new orb
                if (respawnTimer >= respawnDelay && GameObject.FindGameObjectsWithTag("Orb").Length < maxOrbs)
                {
                    SpawnOrb();
                    respawnTimer = 0f;
                }

                // Increase max orbs on collecting 10 orbs
                if (collectedOrbs >= 10)
                {
                    maxOrbs += orbsToAdd;
                    player.UpdatePlayerSpeed();
                    collectedOrbs = 0; // Reset counter
                }
            }
            orbCountsText.text = GameObject.FindGameObjectsWithTag("Orb").Length.ToString();
        }
    }

    public void SpawnInitialOrbs()
    {
        // Spawn initial orbs
        for (int i = 0; i < maxOrbs; i++)
        {
            SpawnOrb();
        }

        orbCountsText.text = GameObject.FindGameObjectsWithTag("Orb").Length.ToString();

        initialOrbsSpawned = true;
    }

    void SpawnOrb()
    {
        // Get random position and color
        Vector3 spawnPosition = new Vector3(Random.Range(-xPos.position.x + boundaryOffset, xPos.position.x - boundaryOffset), 
            Random.Range(-yPos.position.y + boundaryOffset, yPos.position.y - boundaryOffset));

        OrbColorSO orbColorSO = orbColors[Random.Range(0, orbColors.Length)];

        // Create orb object
        Orb newOrb = Instantiate(orbPrefab, spawnPosition, Quaternion.identity);
        newOrb.SetOrbColor(orbColorSO);
        newOrb.gameObject.tag = "Orb";
        newOrb.gameObject.transform.parent = orbsParent;
    }

    public void IncreaseCollectedOrbs()
    {
        collectedOrbs++;
        score++;
        scoreText.text = score.ToString();
    }

    public Color FindOrbColor(int orbId)
    {
        foreach(OrbColorSO orbColorSO in orbColors)
        {
            if(orbId == orbColorSO.GetColorID())
            {
                return orbColorSO.GetColor();
            }
        }

        return Color.white;
    }

    public int GetScore()
    {
        return score;
    }
}
