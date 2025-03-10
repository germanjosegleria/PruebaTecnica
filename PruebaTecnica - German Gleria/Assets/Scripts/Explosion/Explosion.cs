using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip sonidoExplosion;
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        if (sonidoExplosion != null)
        {
            audioSource.PlayOneShot(sonidoExplosion);
        }

        
        float animationDuration = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, animationDuration);
    }
}
