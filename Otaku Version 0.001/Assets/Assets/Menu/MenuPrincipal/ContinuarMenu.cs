using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class ContinuarMenu : MonoBehaviour
{
    public string nombreDeLaEscena; // El nombre de la escena a la que quieres cambiar

    // M�todo que se llama cuando se presiona el bot�n de continuar
    public void ContinuarPartida()
    {
        // Cargar los datos guardados del archivo JSON en GameData
        GameData.LoadMoney(); // Carga el dinero, salud, penalizaci�n, etc.

        // Cambiar a la escena donde se contin�a la partida
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}