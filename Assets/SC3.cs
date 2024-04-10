using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SC3 : MonoBehaviour
{

    Button start;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.Find("StartButton").GetComponent<Button>();
        start.onClick.AddListener(nextScene);
    }

    void nextScene()
    {
        SceneManager.LoadScene("Game");
    }
}
