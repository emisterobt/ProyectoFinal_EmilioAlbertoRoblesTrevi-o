using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcesing : MonoBehaviour
{
    private PostProcessVolume vol;

    private LensDistortion dist;
    private ChromaticAberration chrom;
    private ColorGrading grad;
    private Bloom bloom;

    public bool cambio;

    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        vol.profile.TryGetSettings(out dist);
        vol.profile.TryGetSettings(out chrom);
        vol.profile.TryGetSettings(out grad);
        vol.profile.TryGetSettings(out bloom);
        StartCoroutine(Intercambio());
    }

    void Update()
    {

        if (cambio)
        {
            Aumento();
        }
        if (!cambio)
        {
            Disminucion();
        }
        
    }

    IEnumerator Intercambio()
    {
        yield return new WaitForSeconds(10);
        cambio = !cambio;
        StartCoroutine(Intercambio());
    }

    private void Aumento()
    {
        dist.intensity.value -= 1 * Time.deltaTime;
        chrom.intensity.value += 1f * Time.deltaTime;
        grad.saturation.value += 1f * Time.deltaTime;
        grad.contrast.value += 1f * Time.deltaTime;
        bloom.intensity.value += 1f * Time.deltaTime;
    }
    private void Disminucion()
    {
        dist.intensity.value += 1 * Time.deltaTime;
        chrom.intensity.value -= 1f * Time.deltaTime;
        grad.saturation.value -= 1f * Time.deltaTime;
        grad.contrast.value -= 1f * Time.deltaTime;
        bloom.intensity.value -= 1f * Time.deltaTime;
    }
}
