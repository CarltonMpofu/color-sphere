using UnityEngine;
using TMPro;

public class OrbManager : MonoBehaviour
{
    // Orb properties
    [Header("Orb Properties")]
    [SerializeField] GameObject orbPrefab;
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

        // Collected orbs count
    int collectedOrbs = 0;

    void Start()
    {
        // Spawn initial orbs
        for (int i = 0; i < maxOrbs; i++)
        {
            SpawnOrb();
        }

        orbCountsText.text = GameObject.FindGameObjectsWithTag("Orb").Length.ToString();
    }

    void Update()
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
            collectedOrbs -= 10; // Reset counter
        }

        orbCountsText.text = GameObject.FindGameObjectsWithTag("Orb").Length.ToString();
    }

    void SpawnOrb()
    {
        // Get random position and color
        Vector3 spawnPosition = new Vector3(Random.Range(-xPos.position.x + boundaryOffset, xPos.position.x - boundaryOffset), 
            Random.Range(-yPos.position.y + boundaryOffset, yPos.position.y - boundaryOffset));

        OrbColorSO orbColorSO = orbColors[Random.Range(0, orbColors.Length)];  
        Color randomColor = orbColorSO.GetColor();

        // Create orb object
        GameObject newOrb = Instantiate(orbPrefab, spawnPosition, Quaternion.identity);
        newOrb.tag = "Orb";
        newOrb.transform.parent = orbsParent;

        // Set orb color
        newOrb.GetComponent<Renderer>().material.color = randomColor;
    }

    public void IncreaseCollectedOrbs()
    {
        collectedOrbs++;
    }
}
