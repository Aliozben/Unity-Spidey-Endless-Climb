using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public Sprite Sound_OnImg, Sound_OffImg;
    public bool Sound_On = true;
    public AudioSource auidos;

    void Start()
    {
        auidos = GetComponent<AudioSource>();
        auidos.Play();
    }

    void Update()
    {
        switch (Sound_On)
        {
            case true: GetComponent<Image>().sprite = Sound_OnImg; break;
            case false: GetComponent<Image>().sprite = Sound_OffImg; break;
        }
    }

    public void SoundImageChange()
    {
        Sound_On = !Sound_On;

        if (Sound_On)
            auidos.volume = 0.09f;

        else auidos.volume = 0;
    }

}
