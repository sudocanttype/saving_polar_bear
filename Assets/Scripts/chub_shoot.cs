using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chub_shoot : MonoBehaviour
{
    private ParticleSystem.EmissionModule particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>().emission;
        particles.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
            StartCoroutine(FireParticles());
        }
    }

    IEnumerator FireParticles()
    {
        float timePassed = 0;
        particles.enabled = true;
        while (timePassed < .5)
        {

            timePassed += Time.deltaTime;
    
            yield return null;
         }
        particles.enabled = false;
    }
}
