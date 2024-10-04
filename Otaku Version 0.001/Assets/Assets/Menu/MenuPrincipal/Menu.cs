using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // M�todo que se llama cuando se presiona el bot�n de salir
    public void SalirDelJuego()
    {
        // Cierra la aplicaci�n
        Application.Quit();

        // Este c�digo solo funcionar� dentro del editor de Unity
#if UNITY_EDITOR
        // Detiene el juego en el editor de Unity
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
