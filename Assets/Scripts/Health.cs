using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]private int lifes;

    public bool gameOver { get; private set; }

    public TextMeshProUGUI healthText;

    public void setLifes(int _lifes)
    {
        lifes = _lifes;
    }

    private void LifeRefresh()
    {
        healthText.SetText("lifes: " + lifes);
    }

    public void LooseLife()
    {
        lifes--;
        LifeRefresh();
        if (lifes <= 0)
        {
            gameOver=true;
        }
    }

    public void addLive(int _lifes=1)
    {
        if (gameOver) return;
        lifes += _lifes;
        LifeRefresh();
    }

}
