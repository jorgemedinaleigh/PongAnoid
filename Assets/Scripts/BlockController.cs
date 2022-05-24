using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] float blockResistance =  3f;
    [SerializeField] float blockThreshold = 1;
    [SerializeField] Material brickMat;
    [SerializeField] GameObject explosionParticles;

    AudioSource blockAudioSource;
    float timeToDestroy;

    private void Start()
    {
        blockAudioSource = GetComponent<AudioSource>();
        timeToDestroy = blockAudioSource.clip.length - 0.8f;
    }

    void ProcessHit()
    {
        blockResistance = blockResistance - 1;

        if(blockResistance <= 0)
        {
            blockAudioSource.Play();
            DestroyBlock();
        }
        else if(blockResistance <= blockThreshold)
        {
            gameObject.GetComponent<Renderer>().material = brickMat;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ProcessHit();
        }
    }

    void DestroyBlock()
    {
        GameObject explosion = (GameObject)Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
        Destroy(gameObject, timeToDestroy);
    }
}
