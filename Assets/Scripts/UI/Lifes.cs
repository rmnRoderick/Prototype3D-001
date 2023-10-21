public class Lifes 
{
    private int _lifes;

    public Lifes(int lifes)=>this._lifes = lifes;
    public void addLife(int lifes = 1) => _lifes += lifes;
    public void LooseLife() => _lifes--;    
    public int getRemainingLifes()=>_lifes;
    public string RefreshLifes()=>"lifes: " + _lifes;

}
