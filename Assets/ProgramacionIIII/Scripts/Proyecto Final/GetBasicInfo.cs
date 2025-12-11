using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetBasicInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text displayName;
    public Image perfil;
   
    void Start()
    {

        StartCoroutine(ShowName());
    }

    private IEnumerator ShowName()
    {
        Manager.instance.GetPlayerProfile();
        yield return new WaitForSeconds(3);
        StartCoroutine(ShowImage());
        displayName.text = Manager.instance.displayName;

    }

    IEnumerator ShowImage()
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(Manager.instance.urlImage);

        yield return req.SendWebRequest();



        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(req.error);
            yield break;
        }

        Texture2D tex = DownloadHandlerTexture.GetContent(req);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
        perfil.sprite = sprite;


    }
}
