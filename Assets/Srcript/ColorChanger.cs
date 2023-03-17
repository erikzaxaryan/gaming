using System;
using Firebase.RemoteConfig;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Image _img;
    
    
    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        FirebaseRemoteConfig config = FirebaseRemoteConfig.DefaultInstance;
        
        Task task = config.FetchAsync(TimeSpan.Zero);

        yield return new WaitUntil(() => task.IsCompleted);

        config.ActivateAsync();

        var color = FirebaseRemoteConfig.DefaultInstance.GetValue("Color").StringValue;

        if (color == "green")
        {
            _img.color = Color.green;
        }
        else if (color == "blue")
        {
            _img.color = Color.blue;
        }
    }
}
