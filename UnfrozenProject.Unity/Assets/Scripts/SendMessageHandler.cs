using System;
using Network;
using Network.Factories;
using UnityEngine;
using UnityEngine.UI;

public class SendMessageHandler : MonoBehaviour
{
    [SerializeField] private InputField textField;
    [SerializeField] private Button buttonSend;

    private void Awake()
    {
        textField.onValueChanged.AddListener(OnChangeText);
    }

    private void OnChangeText(string s)
    {
        var newValue = s != "";
        if (buttonSend.interactable != newValue)
            buttonSend.interactable = newValue;
    }

    public void SendMessage()
    {
        TcpClient.Instance.IoCService.GetInstance<SendMessageFactory>().Send(textField.text);
        textField.text = "";
    }
}
