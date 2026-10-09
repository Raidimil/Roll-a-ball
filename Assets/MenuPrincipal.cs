using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar() { SceneManager.LoadScene("Nivel1"); }
    public void Opciones() { SceneManager.LoadScene("Opciones"); }
    public void Volver() { SceneManager.LoadScene("Menu"); }
    public void Salir() { Application.Quit(); }
}