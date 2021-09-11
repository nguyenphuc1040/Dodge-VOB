using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOB : MonoBehaviour
{
    public AudioSource mainAudio;
    public AudioClip tonAC, punchAC;
    void Start()
    {
        mainAudio.PlayOneShot(tonAC);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") mainAudio.PlayOneShot(punchAC); else mainAudio.PlayOneShot(tonAC);
    }
}
