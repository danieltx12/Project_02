using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level01Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitLevel();
        }
    }

    private void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
