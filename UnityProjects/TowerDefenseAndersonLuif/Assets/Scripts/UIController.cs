using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameManager gameManager;
    public GameObject endGamePanel;
    public Text scoreText;
    public Text towerText;
    public Text healthText;
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	void Update () {
        UpdateSelectedTower();
        showIntendedTower();
        updateMoneyText();
        updateHealthText();
	}
    private void updateHealthText()
    {
        healthText.text = "Health: " + gameManager.health;
    }
    private void updateMoneyText()
    {
        scoreText.text = "Resources: " + gameManager.points;
    }
    public void EndGame()
    {
        Time.timeScale = 0;
    }
    private void UpdateSelectedTower()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameManager.intendedTower = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameManager.intendedTower = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameManager.intendedTower = 3;
        }
    }
    private void showIntendedTower()
    {
        if (gameManager.intendedTower == 1)
        {
            towerText.text = "Selected Tower:\nFrost Tower";
        }
        if (gameManager.intendedTower == 2)
        {
            towerText.text = "Selected Tower:\nMelee Tower";
        }
        if (gameManager.intendedTower == 3)
        {
            towerText.text = "Selected Tower:\nArrow Tower";
        }
    }
}
