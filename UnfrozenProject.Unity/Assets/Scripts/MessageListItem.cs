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
        messageText.text = $"[{message.DateTime}] ({message.FromUser.Username}) - {message.Content}";
        messageText.color = ColorTypeConverter.FromArgb(message.FromUser.Color);
        isOnlineStatus.color = message.FromUser.IsOnline 
            ? new Color(0f, 1f, 0f, 0.56f) 
            : new Color(0.69f, 0.69f, 0.69f);
    }
}
