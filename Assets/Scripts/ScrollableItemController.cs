using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScrollableItemController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI name;
    [SerializeField]
    LoadTextureFromURL img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateData(string url, string name)
    {
        img.load(url);
        this.name.text = name;
    }
}
