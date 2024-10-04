using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PruebaMejora : MonoBehaviour
{
    public Button aumentarPenalizacionButton; // Referencia al bot�n en la interfaz
    public float incrementoPenalizacion = 1f; // Valor de incremento de penalizaci�n

    void Start()
    {
        // Asigna el m�todo al bot�n
        aumentarPenalizacionButton.onClick.AddListener(AumentarTiempoPenalizacion);
    }

    void AumentarTiempoPenalizacion()
    {
        // Aumentar el tiempo de penalizaci�n en GameData
        GameData.penalizationTime += incrementoPenalizacion;

        // Guardar el nuevo valor de la penalizaci�n
        GameData.SaveMoney();

        // Imprimir en la consola para ver el nuevo tiempo de penalizaci�n
        Debug.Log("Nuevo tiempo de penalizaci�n: " + GameData.penalizationTime + " segundos");
    }
}