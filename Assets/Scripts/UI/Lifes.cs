using TMPro;

public class Lifes 
{
    private TextMeshProUGUI lifesText;
    private int lifes;

    public Lifes(int _lifes, TextMeshProUGUI _lifesText)
    {
        this.lifes = _lifes;
        this.lifesText = _lifesText;
    }

    public void addLife(int _lifes = 1)
    {
        lifes += _lifes;
        RefreshLifes();
    }

    public void LooseLife()
    {
        lifes--;
        RefreshLifes();
    }

    public void setLifes(int _lifes)
    {
        lifes = _lifes;
    }

    public int getRemainingLifes()
    {
        return lifes;
    }


    public void RefreshLifes()
    {
        lifesText.SetText("lifes: " + lifes);
    }


}
