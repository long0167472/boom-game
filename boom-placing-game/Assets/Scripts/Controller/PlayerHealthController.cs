using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    //public int numOfHearts = 3;

    public Image[] hearts;

    public int heartCount = 3;

    private bool isChangeHeart = false;

    public void minusHeart()
    {
        heartCount--;
        isChangeHeart = true;
    }

    void Update()
    {
        if (isChangeHeart) {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < heartCount)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
            isChangeHeart = false;
        }
    }

}
