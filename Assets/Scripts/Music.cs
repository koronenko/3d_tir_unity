using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFX);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFX);
    }
}
