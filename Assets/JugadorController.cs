using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JugadorController : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoLimite = 60f;
    public string siguienteEscena = "";
    public string escenaMenu = "Menu";

    public TMP_Text textoContador;
    public TMP_Text textoTiempo;
    public TMP_Text textoGanar;

    private Rigidbody rb;
    private int contador;
    private int total;
    private float tiempoRestante;
    private bool terminado;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        total = GameObject.FindGameObjectsWithTag("Coleccionable").Length;
        tiempoRestante = tiempoLimite;
        textoGanar.text = "";
        ActualizarTextos();
    }

    void Update()
    {
        if (terminado) return;

        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            Perder();
        }
        ActualizarTextos();
    }

    void FixedUpdate()
    {
        if (terminado) return;

        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (terminado) return;

        if (other.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            ActualizarTextos();

            if (contador >= total)
            {
                Ganar();
            }
        }
    }

    void OnCollisionEnter(Collision colision)
    {
        if (terminado) return;

        if (colision.gameObject.CompareTag("Obstaculo"))
        {
            Perder();
        }
    }

    void ActualizarTextos()
    {
        textoContador.text = "Contador: " + contador + " / " + total;
        textoTiempo.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);
    }

    void Ganar()
    {
        terminado = true;
        rb.linearVelocity = Vector3.zero;

        if (siguienteEscena == "")
        {
            textoGanar.text = "¡Ganaste!";
            StartCoroutine(CargarEscena(escenaMenu, 5f));
        }
        else
        {
            textoGanar.text = "¡Nivel completado!";
            StartCoroutine(CargarEscena(siguienteEscena, 3f));
        }
    }

    void Perder()
    {
        terminado = true;
        rb.linearVelocity = Vector3.zero;
        textoGanar.text = "¡Perdiste!";
        StartCoroutine(CargarEscena(escenaMenu, 5f));
    }

    IEnumerator CargarEscena(string nombre, float segundos)
    {
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(nombre);
    }
}