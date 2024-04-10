using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuSC1 : MonoBehaviour
{
    private Button _startB;
    private Button _creditB;
    private Button _quitB;
    private Button _backB;

    private GameObject _creditP;

    private void Awake()
    {
        _creditP = GameObject.Find("CreditPanel");
    }

    private void Start()
    {
        _startB = GameObject.Find("StartGameButton").GetComponent<Button>();
        _creditB = GameObject.Find("CreditGameButton").GetComponent<Button>();
        _quitB = GameObject.Find("ExitGameButton").GetComponent<Button>();
        _backB = GameObject.Find("GoBackButton").GetComponent<Button>();

        _creditP.SetActive(false);

        _startB.onClick.AddListener(StartGame);
        _creditB.onClick.AddListener(CreditGame);
        _quitB.onClick.AddListener(QuitGame);
        _backB.onClick.AddListener(GoBackGame);

    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void CreditGame()
    {
        _creditP.SetActive(true);
    }
    void GoBackGame()
    {
        _creditP.SetActive(false);
    }
    void QuitGame()
    {
        Application.Quit();
    }


}
