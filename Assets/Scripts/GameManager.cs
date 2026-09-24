using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // OBLIGATORIO para poder reiniciar la escena

public class GameManager : MonoBehaviour
{
    [Header("Puntuación")]
    public int puntuacion = 0;
    public TextMeshProUGUI textoEnPantalla;

    [Header("Pausa")]
    public GameObject menuPausa; // El panel visual de la pausa
    private bool estaPausado = false;

    void Update()
    {
        // Detecta si pulsamos la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        textoEnPantalla.text = "Puntos: " + puntuacion;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true); // Muestra el panel oscuro con botones
        Time.timeScale = 0f; // Congela el tiempo a velocidad 0
        estaPausado = true;
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false); // Oculta el panel
        Time.timeScale = 1f; // El tiempo vuelve a fluir con normalidad (velocidad 1)
        estaPausado = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f; // Descongelamos el tiempo antes de reiniciar
        // Le pedimos a Unity que vuelva a cargar la escena actual desde el principio
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}