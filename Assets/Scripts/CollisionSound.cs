using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
