using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    

    // M�todo para cerrar la aplicaci�n en Android
    public void ExitGame()
    { 
        Application.Quit();
       
        UnityEditor.EditorApplication.isPlaying = false;

    }
}
