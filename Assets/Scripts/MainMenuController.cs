using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;
     void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
        if(_startingSong != null && AudioManager.Instance == null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }


    public void CloseApp()
    {
        Debug.Log("Quit App");
        Application.Quit();

    }

    public void resetData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }
}
