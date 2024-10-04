using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider vidaSlider;  // Referencia al Slider
    public float tiempoVeneno = 5f; // Duraci�n del veneno en segundos
    public float porcentajeDanio = 0.01f; // Porcentaje de vida a reducir cada vez (10%)

    void Start()
    {
        // Aseg�rate de cargar los datos de GameData
        GameData.LoadMoney();

        // Inicializa el slider con los valores de GameData
        vidaSlider.maxValue = GameData.maxHealth;  // Establecer el valor m�ximo desde GameData
        vidaSlider.value = GameData.currentHealth;  // Establecer la vida actual desde GameData
    }

    // M�todo para recibir da�o
    public void RecibirDanio(float cantidadDanio)
    {
        GameData.currentHealth -= cantidadDanio;  // Reduce la vida en GameData
        if (GameData.currentHealth < 0)
            GameData.currentHealth = 0;  // Asegura que no se baje de 0

        vidaSlider.value = GameData.currentHealth;  // Actualiza el Slider
        GameData.SaveMoney(); // Guardar cambios
    }

    // M�todo para recuperar vida
    public void RecuperarVida(float cantidadVida)
    {
        GameData.currentHealth += cantidadVida;  // Aumenta la vida en GameData
        if (GameData.currentHealth > GameData.maxHealth)
            GameData.currentHealth = GameData.maxHealth;  // Asegura que no se supere la vida m�xima

        vidaSlider.value = GameData.currentHealth;  // Actualiza el Slider
        GameData.SaveMoney(); // Guardar cambios
    }

    // M�todo para iniciar el da�o gradual por veneno
    public void IniciarVeneno()
    {
        StartCoroutine(DanioGradual(tiempoVeneno, porcentajeDanio));
    }

    // Coroutine para aplicar da�o gradual
    private IEnumerator DanioGradual(float duracion, float porcentaje)
    {
        float tiempoPorAplicacion = duracion / (1 / porcentaje); // Tiempo entre cada aplicaci�n de da�o
        for (int i = 0; i < (1 / porcentaje); i++)
        {
            RecibirDanio(GameData.maxHealth * porcentaje); // Aplica el da�o en base al porcentaje
            yield return new WaitForSeconds(tiempoPorAplicacion); // Espera antes de aplicar el siguiente da�o
        }
    }

    // M�todo para reiniciar la vida (opcional)
    public void ReiniciarVida()
    {
        GameData.currentHealth = GameData.maxHealth;  // Reinicia la vida actual a la m�xima
        vidaSlider.value = GameData.currentHealth;  // Actualiza el Slider
        GameData.SaveMoney(); // Guardar cambios
    }
}