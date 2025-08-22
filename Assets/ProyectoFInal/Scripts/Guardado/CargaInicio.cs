
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaInicio : MonoBehaviour
{

    private PerfilJugador perfil;
    public void InicioJuego(string nombreGuardado)
    {
        GameManager.instance.nombreGuardado = nombreGuardado;

        perfil = SistemaGuardado.CargarPartida();


        if (perfil != null)
        {

            GameManager.instance.nivel = perfil.nivel;
            GameManager.instance.enemigosVivos = perfil.enemigosVivos;
            SceneManager.LoadScene(GameManager.instance.nivel);
        }
        else 
        {
            
            SceneManager.LoadScene("TerceraPersona");
            
        }

    }
}
