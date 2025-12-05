using UnityEngine;
using PlayFab;
using TMPro;
using PlayFab.ClientModels;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Networking;

public class Manager : MonoBehaviour
{

    [Header("Login")]
    [SerializeField] private TMP_InputField loginEmail;
    [SerializeField] private TMP_InputField loginPassword;
    [SerializeField] private UnityEvent onLoginSuccess;

    [Header("Create Account")]
    [SerializeField] private TMP_InputField CA_Email;
    [SerializeField] private TMP_InputField CA_Username;
    [SerializeField] private TMP_InputField CA_Password;
    [SerializeField] private TMP_InputField CA_ConfirmPassword;
    [SerializeField] private TMP_InputField CA_AvatarUrl;
    [SerializeField] private UnityEvent onCreateAccountSuccess;

    [Header("UserInfo")]
    [SerializeField] private Image playerPorfilePic;
    [SerializeField] private TMP_Text playerDisplayName;
    private string userPlayFabId;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey))
        {
            PlayFabSettings.DeveloperSecretKey = "IRD6RCAP3TZR8RA3M975G5DGHH35SCHQW4Q4URWD96QPPBYWG6";
        }

        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "41D86";
        }

    }

    // Update is called once per frame
    public void CreateAccount()
    {
        if (CA_Password == CA_ConfirmPassword)
        {
            RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
            {
                Email = CA_Email.text,
                Username = CA_Username.text.ToLower(),
                DisplayName = CA_Username.text,
                Password = CA_Password.text,
                RequireBothUsernameAndEmail = true
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnCreateAccountSuccess, OnError);
        }
        
        else
        {
            Debug.Log("Las Contraseñas no son iguales");
        }
         
    }

    public void SetUserAvatar()
    {
        UpdateAvatarUrlRequest request = new UpdateAvatarUrlRequest
        {
            ImageUrl = CA_AvatarUrl.text,
        };
        PlayFabClientAPI.UpdateAvatarUrl(request, OnSetUserAvatarSuccess, OnError);
    }

    public void OnSetUserAvatarSuccess(EmptyResponse response)
    {
        Debug.Log("Avatar Configurado");
        //StartCoroutine(SetProfilePicOnCanvas(CA_AvatarUrl.text));
    }

    public void OnCreateAccountSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Tu Cuenta fue creada correctamente");
        userPlayFabId = result.PlayFabId;
        onCreateAccountSuccess?.Invoke();
    }

    public void LoginWithEmail()
    {
        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest
        {
            Email = loginEmail.text,
            Password = loginPassword.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

    }

    public void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Has sido Logeado");
        userPlayFabId = result.PlayFabId;
        onLoginSuccess?.Invoke();
    }

    public void GetPlayerProfile()
    {
        GetPlayerProfileRequest request = new GetPlayerProfileRequest
        {
            PlayFabId = userPlayFabId
        };
        PlayFabClientAPI.GetPlayerProfile(request, OnGetAvatarUrlSuccess, OnError);

    }

    public void OnGetAvatarUrlSuccess(GetPlayerProfileResult result)
    {
        playerDisplayName.text = result.PlayerProfile.DisplayName;
        //StartCoroutine(SetProfilePicOnCanvas(result.PlayerProfile.AvatarUrl));
    }

    public void OnError(PlayFabError error)
    {
        Debug.Log(error);
    }

    public int score;

    [ContextMenu("UpdateScore")]

    public void UpdateScore()
    {
        UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Score",
                Value = score
                },
                
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnPlayerStatsUpdateSuccess, OnError);    
    }

    public void OnPlayerStatsUpdateSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Tu Score se actualizó correctamente");
    }

    //private IEnumerator SetProfilePicOnCanvas(string url)
    //{
    //    UnityWebRequestTexture
    //}
    
}
