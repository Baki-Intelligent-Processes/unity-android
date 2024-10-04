using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEfects : MonoBehaviour
{
    public RectTransform subMenu; // El men� que se deslizar�
    public Vector3 startPosition; // Posici�n inicial del men�
    public Vector3 endPosition; // Posici�n final del men�
    public float tiempoDeMovimiento = 0.5f; // Tiempo que tarda en desplazarse

    private bool isOpen = false; // Controla si el men� est� abierto o cerrado

    void Start()
    {
        // Establecer la posici�n inicial del men�
        subMenu.localPosition = startPosition; // Aseg�rate de que use localPosition para la UI
    }

    public void ToggleMenu()
    {
        if (isOpen)
        {
            // Si el men� est� abierto, se mover� hacia la posici�n inicial
            StartCoroutine(Mover(tiempoDeMovimiento, subMenu.localPosition, startPosition));
        }
        else
        {
            // Si el men� est� cerrado, se mover� hacia la posici�n final
            StartCoroutine(Mover(tiempoDeMovimiento, subMenu.localPosition, endPosition));
        }

        isOpen = !isOpen; // Cambiar el estado del men�
    }

    IEnumerator Mover(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            subMenu.localPosition = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        subMenu.localPosition = posFin; // Asegurarse de que termine exactamente en la posici�n final
    }
}