using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SistemaGuardado
{
    public static void GuardarPartida()
    {
        //Direccion donde se guarda el archivo
        string path = Application.dataPath + GameManager.instance.nombreGuardado;
        
        //Se crea flujo de informacion con la direccion y accion
        FileStream stream = new FileStream(path, FileMode.Create);

        //Mandamos a llamar la informacion que se va a guardar
        PerfilJugador perfil = new PerfilJugador();

        //Creamos una variable de formato binario
        BinaryFormatter formatter = new BinaryFormatter();

        //Encriptar en binario la info
        formatter.Serialize(stream, perfil);

        //Se cierra el flujo de informacion 
        stream.Close();
    }

    public static PerfilJugador CargarPartida()
    {
        string path = Application.dataPath + GameManager.instance.nombreGuardado;

        if (File.Exists(path))
        {

            FileStream stream = new FileStream(path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            PerfilJugador perfil = formatter.Deserialize(stream) as PerfilJugador;

            stream.Close();

            return perfil;
        }
        else 
        {
            Debug.Log("No se encontro archivo");

            return null;    
        }
    }
    
}
