using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AudioManager instance;

    public Sonido[] sonidos;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Sonido s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string nombre)
    {
        foreach (Sonido s in sonidos)
        {
            if (s.nombre == nombre)
            {
                s.source.Play();
                return;
            }
            Debug.Log("esa no la manejamos papito" + nombre);
        }
    }

    public void Stop(string nombre)
    {
        foreach (Sonido s in sonidos)
        {
            if (s.nombre == nombre)
            {
                s.source.Stop();
                return;
            }
            Debug.Log("esa no la manejamos papito" + nombre);
        }
    }


}
