using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void ShowGameOverCanvas()
    {
        // first hide game canvas
        gameCanvas.gameObject.SetActive(false);

        // now show game over canvas
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
