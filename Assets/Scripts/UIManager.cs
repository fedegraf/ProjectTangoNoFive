using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Victory;
    [SerializeField] private GameObject Defeat;
    [SerializeField] private GameObject PlayingUI;
    [SerializeField] private Text Life;
    [SerializeField] private Text HelpText;
    // Start is called before the first frame update
    void Start()
    {
     MainMenu.SetActive(true);
     Victory.SetActive(false);
     Defeat.SetActive(false);
     PlayingUI.SetActive(false);
     GameManager.StartGameEvent += StartPlaying;
     GameManager.GameOverEvent += LossingEvent;
     GameManager.WinGameEvent += WinningEvent;
     GameObject player = GameObject.FindWithTag("Player");
     player.GetComponent<HealthScript>().LifeChange += UpdateHealthText;
    }

    void StartPlaying()
    {
        MainMenu.SetActive(false);
        PlayingUI.SetActive(true);
        Defeat.SetActive(false);
    }

    void WinningEvent()
    {
        Victory.SetActive(true);
        PlayingUI.SetActive(false);
        
    }

    void LossingEvent()
    {
        Defeat.SetActive(true);
        PlayingUI.SetActive(false);
    }

    void UpdateHealthText(float life)
    {
        Life.text = $"Life: {life}%";
    }

    void ChangeHelpText(int Room)
    {
        switch (Room)
        {
            case 1:
                HelpText.text = "Hitting the base of the lasers disables them";
                break;
            case 2:
                HelpText.text = "Watch out for the turrets! You can disable them but you will be exposed";
                break;
            case 3:
                HelpText.text = "Shoot the platforms to move the entire color set, be careful with the bombs";
                break;
            case 4:
                HelpText.text = "Use all your learnings to press the button on top of the bomb turret";
                break;
        }

    }
}
