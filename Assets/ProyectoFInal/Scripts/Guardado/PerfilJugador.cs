using UnityEngine;

[System.Serializable]
public class PerfilJugador
{
    public int enemigosVivos;

    public string nivel;

    public PerfilJugador()
    {
        enemigosVivos = GameManager.instance.enemigosVivos;
        nivel = GameManager.instance.nivel;
    }


}
