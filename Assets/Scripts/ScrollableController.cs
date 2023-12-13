using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableController : MonoBehaviour
{
    [SerializeField]
    private GameObject uiItem;
    [SerializeField]
    private Transform container;

    [SerializeField]
    private string testingData;

    ScrollableData data;
    private void Start()
    {
        data = JsonUtility.FromJson<ScrollableData>(testingData);
        print(data.data.Count);

        Fetch(data);
    }
    public void Fetch(ScrollableData scrollableData)
    {
        foreach(ScrollableItemData item in scrollableData.data)
        {
            GameObject newItem = Instantiate(uiItem,container);
            newItem.GetComponent<ScrollableItemController>().UpdateData(item.imageURL, item.name);
        }

    }

}
[System.Serializable]
public class ScrollableData
{
    public List<ScrollableItemData> data;
    ScrollableData()
    {
        data = new List<ScrollableItemData>();
    }
}
[System.Serializable]
public class ScrollableItemData
{
    public string imageURL;
    public string name;
}

