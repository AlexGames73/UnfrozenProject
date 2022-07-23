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

    [SerializeField] private GameObject logInCanvas;
    [SerializeField] private GameObject messagesCanvas;
    
    public void LogInClicked()
    {
        if (TcpClient.Instance.CurrentSession == null)
        {
            Debug.LogError("Server is not reached!");
            return;
        }
        
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
        usernameInputFieldError.text = TcpClient.Instance.CurrentSession.LogInError;
    }

    public void LoggedIn()
    {
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
