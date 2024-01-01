using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numOfHearts = 3;

    public Image[] hearts;

    void Update()
    {
        PlayerBombController player = GetComponent<PlayerBombController>();
        if (numOfHearts == player.heartCount)
        {
            return;
        }
        numOfHearts = player.heartCount;
        for (int i = 0; i < hearts.Length; i++) {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
