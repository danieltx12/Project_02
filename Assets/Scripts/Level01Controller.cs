using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] Image _healthBar;
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _deathMenu;
    [SerializeField] GameObject player;
    bool menuState = false;
    bool cursorState = false;
    int _currentScore;
    int playerHealth = 500;

     void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           CursorFix();
            
        }

      /* if (Input.GetKeyDown(KeyCode.Q))
            {
            IncreaseScore(5);
            }
            */
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level01");
    }
    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }

    public void CursorFix()
    {
        menuState = !menuState;
        _menu.SetActive(menuState);
           
        Cursor.visible = !cursorState;
        cursorState = !cursorState;
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Debug.Log("TOGGLE");
    }

    public void Damage()
    {
        playerHealth -= 100;
        _healthBar.rectTransform.sizeDelta = new Vector2(playerHealth, 100);
        if (playerHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _deathMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.SetActive(false);
    }
}
