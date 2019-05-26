using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public Text TiedGameText;
    [Space]
    public Button MuteToggleButton;
    public Text MuteToggleText;

    private void Start()
    {
    }
    void Update()
    {
        Player1ScoreText.text = "" + GameData.SCORE_PLAYER_1;
        Player2ScoreText.text = "" + GameData.SCORE_PLAYER_2;
        TiedGameText.text = "" + GameData.TIED_GAME;
    }

    public void MuteAudio()
    {
        if (!AudioListener.pause)
        {
            MuteToggleText.text = "SOUND FX: OFF";
            MuteToggleButton.GetComponent<Image>().color = GameData.COLOR_PLAYER_RED;
            AudioListener.pause = true;
        }
        else
        {
            MuteToggleText.text = "SOUND FX: ON";
            MuteToggleButton.GetComponent<Image>().color = GameData.COLOR_PLAYER_GREEN;
            AudioListener.pause = false;
        }
    }
}
