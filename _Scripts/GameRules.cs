using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    [Header("Audio")]
    public AudioManager GameAudioManager;

    bool playersTurn = true;
    bool isEnemyAI = false;

    bool gameWon = false;

    [Header("Block Data")]
    public int[] blocks;
    [Space]
    [Header("Block Buttons")]
    public Button[] GameBlock;
    [Space]
    [Header("Block Texts")]
    public Text[] BlockText;
    [Space]
    public Text GameMessageText;
    public Button ResetGameButton;


    void Awake()
    {
        GameData.SCORE_PLAYER_1 = 0;
        GameData.SCORE_PLAYER_2 = 0;
    }


    void Start()
    {
        ResetGameButton.interactable = false;
    }

    void Update()
    {
    }

    public void PressBlock(int blockNum)
    {


        if (playersTurn)
        {
            EndTurnResponse(blockNum, 1, "X", GameData.COLOR_PLAYER_RED);

            playersTurn = false;

        }
        else if (!playersTurn && !isEnemyAI)
        {
            EndTurnResponse(blockNum, 2, "O", GameData.COLOR_PLAYER_BLUE);
            playersTurn = true;
        }

        if (isEnemyAI)
        {
            CheckBlockIfEmpty();
        }

        CheckGameConditions();
        GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_BLOCK_CLICKED);
    }

    void CheckBlockIfEmpty()
    {
        int randomBlock = Random.Range(0, blocks.Length);
        if (blocks[randomBlock] != 0)
        {
            CheckBlockIfEmpty();
        }
        else
        {
            EndTurnResponse(randomBlock, 2, "O", GameData.COLOR_PLAYER_BLUE);
            playersTurn = true;
        }
    } // NOT IN USE

    void EndTurnResponse(int blockNum, int playerNum, string symbol, Color32 symbolColor)
    {
        blocks[blockNum] = playerNum;
        BlockText[blockNum].gameObject.SetActive(true);
        BlockText[blockNum].text = symbol;
        BlockText[blockNum].color = symbolColor;
        GameBlock[blockNum].GetComponent<Image>().color = Color.black;
        GameBlock[blockNum].interactable = false;
    }

    public void CheckGameConditions()
    {
        // XXX
        // ***
        // ***
        if (blocks[0] == 1 && blocks[1] == 1 && blocks[2] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(0, 1, 2);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // OOO
        // ***
        // ***
        else if (blocks[0] == 2 && blocks[1] == 2 && blocks[2] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(0, 1, 2);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // ***
        // XXX
        // ***
        else if (blocks[3] == 1 && blocks[4] == 1 && blocks[5] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(3, 4, 5);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // ***
        // OOO
        // ***
        else if (blocks[3] == 2 && blocks[4] == 2 && blocks[5] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(3, 4, 5);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // ***
        // ***
        // XXX
        else if (blocks[6] == 1 && blocks[7] == 1 && blocks[8] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(6, 7, 8);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // ***
        // ***
        // OOO
        else if (blocks[6] == 2 && blocks[7] == 2 && blocks[8] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(6, 7, 8);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // X**
        // X**
        // X**
        else if (blocks[0] == 1 && blocks[3] == 1 && blocks[6] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(0, 3, 6);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // O**
        // O**
        // O**
        else if (blocks[0] == 2 && blocks[3] == 2 && blocks[6] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(0, 3, 6);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // *X*
        // *X*
        // *X*
        else if (blocks[1] == 1 && blocks[4] == 1 && blocks[7] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(1, 4, 7);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // *O*
        // *O*
        // *O*
        else if (blocks[1] == 2 && blocks[4] == 2 && blocks[7] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(1, 4, 7);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // **X
        // **X
        // **X
        else if (blocks[2] == 1 && blocks[5] == 1 && blocks[8] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(2, 5, 8);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // **O
        // **O
        // **O
        else if (blocks[2] == 2 && blocks[5] == 2 && blocks[8] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(2, 5, 8);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // X**
        // *X*
        // **X
        else if (blocks[0] == 1 && blocks[4] == 1 && blocks[8] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(0, 4, 8);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // O**
        // *O*
        // **O
        else if (blocks[0] == 2 && blocks[4] == 2 && blocks[8] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(0, 4, 8);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }
        // **X
        // *X*
        // X**
        else if (blocks[2] == 1 && blocks[4] == 1 && blocks[6] == 1)
        {
            GameData.SCORE_PLAYER_1++;
            playersTurn = true;
            ColorWinningBlock(2, 4, 6);
            ShowGameMessage("PLAYER 1 WINS THE ROUND!", GameData.COLOR_PLAYER_RED);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_1_VICTORY);
            LockBlocks();
        }
        // **O
        // *O*
        // O**
        else if (blocks[2] == 2 && blocks[4] == 2 && blocks[6] == 2)
        {
            GameData.SCORE_PLAYER_2++;
            playersTurn = false;
            ColorWinningBlock(2, 4, 6);
            ShowGameMessage("PLAYER 2 WINS THE ROUND!", GameData.COLOR_PLAYER_BLUE);
            GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_PLAYER_2_VICTORY);
            LockBlocks();
        }

        if (CheckIfTie())
        {
            ShowGameMessage("ROUND DRAW!", Color.white);
            GameData.TIED_GAME++;
        }
    }

    public void ResetGame()
    {
        gameWon = false;
        ResetGameButton.interactable = false;

        GameAudioManager.GameAudio.PlayOneShot(GameAudioManager.AUDIO_BUTTON_NEW_ROUND);
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = 0;
            GameBlock[i].interactable = true;
            GameBlock[i].gameObject.SetActive(false);
            GameBlock[i].gameObject.SetActive(true);
            GameBlock[i].GetComponent<Image>().color = Color.white;
            BlockText[i].color = Color.white;
            BlockText[i].gameObject.SetActive(false);
            Debug.Log(blocks[i]);
        }

        if (playersTurn)
        {
            ShowGameMessage("PLAYER 1 WILL HAVE THE FIRST TURN!", GameData.COLOR_PLAYER_RED);
        }
        else
        {
            ShowGameMessage("PLAYER 2 WILL HAVE THE FIRST TURN!", GameData.COLOR_PLAYER_BLUE);
        }
    }

    void LockBlocks()
    {
        gameWon = true;
        for (int i = 0; i < blocks.Length; i++)
        {
            GameBlock[i].interactable = false;
        }

        ResetGameButton.interactable = true;
    }

    bool CheckIfTie()
    {
        if (!gameWon)
        {
            int emptyIndex = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] != 0)
                {
                    emptyIndex++;
                }
            }
            if (emptyIndex >= 9)
            {
                ResetGameButton.interactable = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void ColorWinningBlock(int blockNum1, int blockNum2, int blockNum3)
    {
        BlockText[blockNum1].color = Color.yellow;
        BlockText[blockNum2].color = Color.yellow;
        BlockText[blockNum3].color = Color.yellow;
    }

    void ShowGameMessage(string message, Color32 color)
    {
        GameMessageText.color = color;
        GameMessageText.gameObject.SetActive(false);
        GameMessageText.gameObject.SetActive(true);
        GameMessageText.text = message.ToString();
    }
}
