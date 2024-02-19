using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject playerJoystick;

    [SerializeField] Image pauseButtonImage;


    OrbManager orbManager;

    // Start is called before the first frame update
    void Start()
    {
        gameCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);

        orbManager = FindObjectOfType<OrbManager>();

    }

    public void ShowGameOverCanvas()
    {
        // first hide game canvas
        gameCanvas.gameObject.SetActive(false);

        // now show game over canvas
        gameOverCanvas.gameObject.SetActive(true);

        scoreText.text = $"Score: {orbManager.GetScore()}";
    }

    public void PauseGame()
    {
        playerJoystick.SetActive(false);
        pauseButtonImage.color = Color.red;
    }

    public void UnPauseGame()
    {
        playerJoystick.SetActive(true);
        pauseButtonImage.color = Color.white;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
