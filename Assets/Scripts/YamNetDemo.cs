using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YamNetUnity;

[DisallowMultipleComponent]
[RequireComponent(typeof(YamNet))]
public class YamNetDemo : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        var yamnet = GetComponent<YamNet>();
        yamnet.onResult.AddListener(YamNetResultCallback);
        yamnet.StartMicrophone();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void YamNetResultCallback(int bestClassId, string bestClassName, float bestScore)
    {
        if (bestScore > 0.65)
        {
            string status = $"{bestClassName}";

            this.text.text = status;
            Debug.Log(status);
        }
    }
}
