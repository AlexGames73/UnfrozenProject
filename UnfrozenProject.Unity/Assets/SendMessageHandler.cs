using Network;
using Network.Factories;
using UnityEngine;
using UnityEngine.UI;

public class SendMessageHandler : MonoBehaviour
{
    [SerializeField] private InputField textField;

    public void SendMessage()
    {
        TcpClient.Instance.IoCService.GetInstance<SendMessageFactory>().Send(textField.text);
        textField.text = "";
    }
}
