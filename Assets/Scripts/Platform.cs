using UnityEngine;

public class Platform:MonoBehaviour
{

    [SerializeField] private float score;

    public float GetScore()
    {
        var oldScore = score;
        score = 0;
        return oldScore;
    }


}
