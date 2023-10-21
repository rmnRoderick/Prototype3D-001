
public class Score
{
    private float _score = 0;
    private readonly INotifier _eventController;

    public Score(INotifier eventController, int score = 0)
    {
        _score = score;
        _eventController = eventController;
    }
    public void addScore(float score)=>_score += score;
    public string RefreshScore()=> "Score: " + _score;
    
}
