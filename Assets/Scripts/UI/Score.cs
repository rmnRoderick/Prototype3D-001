
public class Score
{
    private float _score = 0;
    public void addScore(float score)=>_score += score;
    public string RefreshScore()=> "Score: " + _score;
    
}
