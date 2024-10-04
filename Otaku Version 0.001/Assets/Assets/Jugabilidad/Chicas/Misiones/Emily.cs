using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Emily : MonoBehaviour
{
    [Header("Configuraci�n del Di�logo")]
    public TMP_Text dialogueText; // Referencia al texto donde se mostrar� el di�logo
    public string[] emilyLines; // L�neas de di�logo de Emily
    public string[] playerLines; // L�neas de di�logo del jugador
    private int currentLineIndex = 0; // �ndice actual del di�logo
    private bool isEmilyTurn = true; // Bandera para saber de qui�n es el turno

    void Start()
    {
        // Iniciar di�logo desde el primer turno de Emily
        ShowNextDialogue();
    }

    void Update()
    {
        // Si el jugador presiona la tecla Espacio, el di�logo avanza
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogue();
        }
    }

    private void ShowNextDialogue()
    {
        if (isEmilyTurn)
        {
            // Si es el turno de Emily y hay l�neas para mostrar
            if (currentLineIndex < emilyLines.Length)
            {
                dialogueText.text = "Emily: " + emilyLines[currentLineIndex];
                isEmilyTurn = false; // Cambia el turno al jugador
            }
        }
        else
        {
            // Si es el turno del jugador y hay l�neas para mostrar
            if (currentLineIndex < playerLines.Length)
            {
                dialogueText.text = "Jugador: " + playerLines[currentLineIndex];
                currentLineIndex++; // Avanza al siguiente �ndice
                isEmilyTurn = true; // Cambia el turno a Emily
            }
        }
    }
}
