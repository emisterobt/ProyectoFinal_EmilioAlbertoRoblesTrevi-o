using UnityEngine;

[System.Serializable]
public class PerfilJugador
{
    public int colect;

    public float posX;
    public float posY;
    public float posZ;

    public int enemigosVivos;

    public string nivel;

    public PerfilJugador()
    {
        colect = GameManager.instance.colect;

        enemigosVivos = GameManager.instance.enemigosVivos;
        nivel = GameManager.instance.nivel;

    }


}
