using UnityEngine;
using TMPro;

public class OrbManager : MonoBehaviour
{
    // Orb properties
    [SerializeField] GameObject orbPrefab;
    [SerializeField] int maxOrbs = 5;
    [SerializeField] int orbsToAdd = 5;
    [SerializeField] Color[] orbColors; // Array of possible orb colors

    // Collected orbs count
    private int collectedOrbs = 0;

    // Spawning variables
    [SerializeField] float respawnTimer = 0f;
    [SerializeField] float respawnDelay = 3f; // Delay between orb spawns

    [SerializeField] Transform xPos;
    [SerializeField] Transform yPos;

    [SerializeField] TextMeshProUGUI orbCountsText;

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
        Vector3 spawnPosition = new Vector3(Random.Range(-xPos.position.x, xPos.position.x), 
            Random.Range(-yPos.position.y, yPos.position.y));
        Color randomColor = orbColors[Random.Range(0, orbColors.Length)];

        // Create orb object
        GameObject newOrb = Instantiate(orbPrefab, spawnPosition, Quaternion.identity);
        newOrb.tag = "Orb";

        // Set orb color
        newOrb.GetComponent<Renderer>().material.color = randomColor;
    }

    public void IncreaseCollectedOrbs()
    {
        collectedOrbs++;
    }
}
