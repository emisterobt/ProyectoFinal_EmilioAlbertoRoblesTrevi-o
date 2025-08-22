using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Posti : MonoBehaviour
{
    private PostProcessVolume vol;

    private LensDistortion dist;
    private ChromaticAberration chrom;
    private ColorGrading grad;
    private Bloom bloom;
    private Vignette vig;

    public bool cambio;

    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        vol.profile.TryGetSettings(out dist);
        vol.profile.TryGetSettings(out chrom);
        vol.profile.TryGetSettings(out grad);
        vol.profile.TryGetSettings(out bloom);
        vol.profile.TryGetSettings(out vig);
        StartCoroutine(Intercambio());
    }

    // Update is called once per frame
    void Update()
    {

   

        if (cambio)
        {
            dist.intensity.value -= 1 * Time.deltaTime;
            chrom.intensity.value += 1f * Time.deltaTime;
            grad.saturation.value += 1f * Time.deltaTime;
            grad.contrast.value += 1f * Time.deltaTime;
            bloom.intensity.value += 1f * Time.deltaTime;
        }
        if (!cambio)
        {
            dist.intensity.value += 1 * Time.deltaTime;
            chrom.intensity.value -= 1f * Time.deltaTime;
            grad.saturation.value -= 1f * Time.deltaTime;
            grad.contrast.value -= 1f * Time.deltaTime;
            bloom.intensity.value -= 1f * Time.deltaTime;
        }
        
    }

    IEnumerator Intercambio()
    {
        yield return new WaitForSeconds(10);
        cambio = !cambio;
        StartCoroutine(Intercambio());
    }
}
