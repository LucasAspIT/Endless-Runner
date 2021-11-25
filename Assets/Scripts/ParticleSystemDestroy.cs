using UnityEngine;

public class ParticleSystemDestroy : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps)
        {
            // Destroy the particle if it's done playing the animation.
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
