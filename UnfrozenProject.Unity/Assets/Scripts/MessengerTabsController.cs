using UnityEngine;
using UnityEngine.UI;

public class MessengerTabsController : MonoBehaviour
{
    [SerializeField] private Button buttonMessages;
    [SerializeField] private Button buttonOnline;

    [SerializeField] private GameObject messagesMenu;
    [SerializeField] private GameObject onlineMenu;
    
    public void OnlineClicked()
    {
        Switch(true);
    }

    public void MessagesClicked()
    {
        Switch(false);
    }

    private void Switch(bool flag)
    {
        buttonMessages.interactable = flag;
        buttonOnline.interactable = !flag;
        
        messagesMenu.SetActive(!flag);
        onlineMenu.SetActive(flag);
    }
}
