using System.Collections.Generic;
using System.Linq;
using Structs;
using UnityEngine;

public class OnlineHandler : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject onlineListItemPrefab;
    
    private List<OnlineListItem> _onlineListItems;

    private void Awake()
    {
        _onlineListItems = content.GetComponentsInChildren<OnlineListItem>(true).ToList();
    }

    public void UpdateOnline(List<User> users)
    {
        for (var i = _onlineListItems.Count; i < users.Count; i++)
        {
            var instantiate = Instantiate(onlineListItemPrefab, content);
            instantiate.SetActive(false);
            _onlineListItems.Add(instantiate.GetComponent<OnlineListItem>());
        }
        
        for (var i = 0; i < users.Count; i++)
        {
            _onlineListItems[i].gameObject.SetActive(true);
            _onlineListItems[i].SetUser(users[i]);
        }

        for (var i = users.Count; i < _onlineListItems.Count; i++)
        {
            _onlineListItems[i].gameObject.SetActive(false);
        }
    }
}
