using UnityEngine;

public class InicioJuego : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.DeleteAll(); // Reinicia todas las playerprefs cuando inica una partida nueva.
    }

    
    void Update()
    {
        
    }
}
