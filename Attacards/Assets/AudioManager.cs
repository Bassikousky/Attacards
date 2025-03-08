using UnityEngine;
using UnityEngine.EventSystems;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip sonidoEspada; 
    [SerializeField] public AudioClip sonidoEscudo; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySonidoEspada()
    {
        if (sonidoEspada != null)
        {
            audioSource.clip = sonidoEspada;
            audioSource.PlayOneShot(sonidoEspada);
        }
        else
        {
            Debug.LogWarning("No se ha asignado sound1 al AudioManager");
        }
    }

    public void PlaySonidoEscudo()
    {
        if (sonidoEscudo != null)
        {
            audioSource.clip = sonidoEscudo;
            audioSource.PlayOneShot(sonidoEscudo);
        }
        else
        {
            Debug.LogWarning("No se ha asignado sound2 al AudioManager");
        }
    }
}