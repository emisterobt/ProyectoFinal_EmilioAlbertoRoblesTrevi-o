using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public GameObject leaderboardRowPrefab;
    public Transform contentContainer;
    public float rowSpacing = 10f;

    void Start()
    {
        GetPlayFabLeaderboard();
    }
    public void GetPlayFabLeaderboard()
    {
        Debug.Log("Descargando dat");
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnError);
    }

    void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log("Descarga de datos exitosa");
        foreach (Transform child in contentContainer)
        {
            Destroy(child.gameObject);
        }

        int i = 0;
        foreach (var item in result.Leaderboard)
        {
            Debug.Log("Resultado " + i);
            GameObject newRow = Instantiate(leaderboardRowPrefab, contentContainer, false);

            RectTransform rt = newRow.GetComponent<RectTransform>();
            if (rt != null)
            {
                float height = rt.rect.height;
                rt.anchoredPosition = new Vector2(0f, -i * (height + rowSpacing));
            }

            float timeInSeconds = item.StatValue / 1f;
            newRow.transform.Find("Puntuacion").GetComponent<TextMeshProUGUI>().text = timeInSeconds.ToString("F2");

            // capture locals for the async callbacks
            string playFabId = item.PlayFabId;
            string displayName = item.DisplayName;
            var usernameText = newRow.transform.Find("Player01").GetComponent<TextMeshProUGUI>();

            if (newRow.transform.Find("Player01").GetComponent<TextMeshProUGUI>() != null) 
            {
                Debug.Log("Username text = " + usernameText.gameObject.name);
     
            }
            else if(usernameText.GetComponent<TextMeshProUGUI>() == null) 
            {
                Debug.LogError("Username text = null " );
            }

            var profileReq = new GetPlayerProfileRequest
            {
                PlayFabId = playFabId,
                ProfileConstraints = new PlayerProfileViewConstraints
                {
                    ShowAvatarUrl = true,
                    ShowDisplayName = true
                }
            };

            PlayFabClientAPI.GetPlayerProfile(profileReq, profileResult =>
            {
                string username = profileResult.PlayerProfile?.DisplayName ?? displayName ?? playFabId;
                usernameText.text = username;      

            }, OnError);

            i++;
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error getting leaderboard: " + error.ErrorMessage);
    }

}
