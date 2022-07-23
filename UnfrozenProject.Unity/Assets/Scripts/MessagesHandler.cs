using System.Collections.Generic;
using Structs;
using UnityEngine;

public class MessagesHandler : MonoBehaviour
{
    [SerializeField] private Transform content;
    
    private MessageListItem[] _messageListItems;

    private void Awake()
    {
        _messageListItems = content.GetComponentsInChildren<MessageListItem>(true);
    }

    public void UpdateMessages(List<Message> messages)
    {
        for (var i = 0; i < messages.Count; i++)
        {
            _messageListItems[i].gameObject.SetActive(true);
            _messageListItems[i].SetMessage(messages[i]);
        }

        for (var i = messages.Count; i < _messageListItems.Length; i++)
        {
            _messageListItems[i].gameObject.SetActive(false);
        }
    }
}
