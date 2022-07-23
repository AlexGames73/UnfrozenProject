using Structs;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class MessageListItem : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Image isOnlineStatus;

    public void SetMessage(Message message)
    {
        messageText.text = $"[{message.DateTime}] ({message.FromUsername}) - {message.Content}";
        messageText.color = ColorTypeConverter.FromArgb(message.FromColor);
        isOnlineStatus.color = message.IsOnline 
            ? new Color(0f, 1f, 0f, 0.56f) 
            : new Color(0.69f, 0.69f, 0.69f);
    }
}
