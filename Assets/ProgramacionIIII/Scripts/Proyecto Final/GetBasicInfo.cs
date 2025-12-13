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
        StartCoroutine(ShowImage(Manager.instance.urlImage, perfil));
        displayName.text = Manager.instance.displayName;

    }

    IEnumerator ShowImage(string url, Image targetImage)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (uwr.result != UnityWebRequest.Result.Success)
#else
            if (uwr.isNetworkError || uwr.isHttpError)
#endif
            {
                Debug.Log("Error downloading avatar: " + uwr.error);
                yield break;
            }

            Texture2D tex = DownloadHandlerTexture.GetContent(uwr);
            if (tex != null)
            {
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                targetImage.sprite = sprite;
            }
        }
    }
}
