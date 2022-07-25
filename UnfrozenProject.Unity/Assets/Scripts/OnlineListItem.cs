using Structs;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class OnlineListItem : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Image isOnlineStatus;

    public void SetUser(User user)
    {
        messageText.text = $"{user.Username}";
        messageText.color = ColorTypeConverter.FromArgb(user.Color);
        isOnlineStatus.color = user.IsOnline 
            ? new Color(0f, 1f, 0f, 0.56f) 
            : new Color(0.69f, 0.69f, 0.69f);
    }
}
