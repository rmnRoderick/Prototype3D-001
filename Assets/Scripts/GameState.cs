using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maxTime <=0)
        {
            Time.timeScale = 0f;
            Debug.Log("Timeout");
        }
        else
        {
            maxTime -= Time.deltaTime;
        }
        timeText.SetText("Time: " + Mathf.Round( maxTime));
    }

}
