using UnityEngine;

public class ScoreObject : MonoBehaviour, IPickeableObject
{
    public float score;

    [SerializeField] private ParticleSystem particlePrefab;
    
    public void Pickup(GameState gameState)
    {
        gameState.score.addScore(score);
        score = 0;

        var particleSys = Instantiate(particlePrefab,transform.position,transform.rotation);
        Destroy(gameObject);

        particleSys.Play();
        Destroy(particleSys,.5f);
    }


}

