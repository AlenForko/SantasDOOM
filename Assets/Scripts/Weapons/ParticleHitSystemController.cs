using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHitSystemController : MonoBehaviour
{
    public ParticleSystem partcilePrefab;
    ParticleSystem[] particles;
    int currentParticle;
    // Start is called before the first frame update
    void Start()
    {
        particles = new ParticleSystem[100];
        GameObject g = new GameObject("HitParticles");
        g.transform.position = Vector3.zero;
        for(int i = 0; i < particles.Length; i++)
        {
            particles[i] = Instantiate(partcilePrefab, g.transform);
        }
    }

    public void PlayAtPosition(Vector3 position)
    {
        particles[currentParticle].transform.position = position;
        particles[currentParticle].Play();
        currentParticle++;
        if(currentParticle >= particles.Length)
        {
            currentParticle = 0;
        }

    }
}
