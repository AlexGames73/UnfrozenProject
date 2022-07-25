using System;
using Acks;
using Network;
using Network.Factories;
using UnityEngine;
using UnityEngine.UI;

public class LogInHandler : MonoBehaviour
{
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private Text usernameInputFieldError;
    [SerializeField] private FlexibleColorPicker flexibleColorPicker;
    [SerializeField] private Text exitButtonText;

    [SerializeField] private GameObject logInCanvas;
    [SerializeField] private GameObject messagesCanvas;

    private CanvasGroup _logInCanvasGroup;

    private void Awake()
    {
        _logInCanvasGroup = logInCanvas.GetComponent<CanvasGroup>();
    }

    public void LogInClicked()
    {
        if (TcpClient.Instance.CurrentSession == null)
        {
            Debug.LogError("Server is not reached!");
            return;
        }

        _logInCanvasGroup.interactable = false;
        exitButtonText.text = $"Exit ({usernameInputField.text})";
        TcpClient.Instance.IoCService.GetInstance<AuthUserFactory>().Send(
            usernameInputField.text, flexibleColorPicker.color);
    }

    public void LogOutClicked()
    {
        logInCanvas.SetActive(true);
        messagesCanvas.SetActive(false);
        
        TcpClient.Instance.CurrentSession.Send(new LogOutUserAck());
    }

    public void LoggedInError()
    {
        _logInCanvasGroup.interactable = true;
        usernameInputFieldError.text = TcpClient.Instance.CurrentSession.LogInError;
    }

    public void LoggedIn()
    {
        _logInCanvasGroup.interactable = true;
        usernameInputFieldError.text = "";
        if (TcpClient.Instance.CurrentSession == null)
        {
            Debug.LogError("Server is not reached!");
            return;
        }
        
        logInCanvas.SetActive(false);
        messagesCanvas.SetActive(true);
        
        TcpClient.Instance.IoCService.GetInstance<GetMessagesFactory>().Send();
    }
}
