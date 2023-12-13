using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Nobi.UiRoundedCorners;
public class LoadTextureFromURL : MonoBehaviour
{
    public string TextureURL = "";
    Image image;
    public Sprite def;
    // Start is called before the first frame update
    private void OnEnable()
    {
        image = GetComponent<Image>();
        if (def!= null)
        {
            image.sprite = def;

        }
    }
   
    public void load(string url)
    {

        TextureURL = url;
        StartCoroutine(DownloadImage(url));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DownloadImage(string MediaUrl)
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            print("try again later!");
        }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            if (image != null)
                image.sprite = webSprite;
           
            if (gameObject.GetComponent<ImageWithRoundedCorners>() != null)
                gameObject.GetComponent<ImageWithRoundedCorners>().Refresh();

        }
    }

   

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }


}