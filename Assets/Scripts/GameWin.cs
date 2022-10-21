using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject gameOverScreen;
	public Text gameState;
	public Text secondsSurvivedUI;
	bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerWin += OnGameWin;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
			if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(0);
		}
    }

    void OnGameWin() {
		gameOverScreen.SetActive(true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameState.text = "You Win :)";
		gameOver = true;
	}
}
