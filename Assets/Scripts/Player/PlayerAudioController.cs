using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource cSource;

    public AudioClip damage;
    public AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage()
    {
        cSource.PlayOneShot(damage);
    }

    public void Jump()
    {
        cSource.PlayOneShot(jump);
    }
}
