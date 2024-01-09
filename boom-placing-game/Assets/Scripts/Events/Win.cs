using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject player1;
    public Image icPlayer1;
    public GameObject player2;
    public Image icPlayer2;
    public TextMeshProUGUI text;
    public void CheckWin()
    {
        WinScreen.SetActive(true);
        if (player1.activeSelf == false && player2.activeSelf == true)
        {
            icPlayer1.enabled = false;
        }
        if (player2.activeSelf == false && player1.activeSelf == true)
        {
            icPlayer2.enabled = false;
        }
        if (player1.activeSelf == false && player2.activeSelf == false)
        {
            text.text = "Draw!";
            icPlayer1.enabled = true;
            icPlayer2.enabled = true;
            icPlayer1.transform.position = new Vector3(-2, 2.4f, 0);
            icPlayer2.transform.position = new Vector3(2, 2.4f, 0);
        }
    }
}
