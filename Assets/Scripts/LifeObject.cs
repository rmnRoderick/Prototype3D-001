using UnityEngine;

public class LifeObject : MonoBehaviour, IPickeableObject
{
    public int lifes;

    [SerializeField] private ParticleSystem particlePrefab;
    
    public void Pickup(GameState gameState)
    {
        gameState.lifes.addLife(lifes);
        lifes = 0;
        //gameState.score.addScore(score);
        //score = 0;

        var particleSys = Instantiate(particlePrefab,transform.position,transform.rotation);
        Destroy(gameObject);

        particleSys.Play();
        Destroy(particleSys,.5f);
    }


}

