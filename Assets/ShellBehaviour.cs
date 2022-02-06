using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class ShellBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private string text = "";

    void Start()
    {
        Input.location.Start(0.1f, 0.1f);
        text = "Tu localización es: \n" + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        Input.location.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(text);
        float distance = Vector3.Distance(transform.position, GameObject.Find("SlimePBR").transform.position);
        if (distance < 5.0f) {
            this.gameObject.transform.GetComponentInChildren<TextMeshPro>().SetText(text);
        } else {
            this.gameObject.transform.GetComponentInChildren<TextMeshPro>().SetText("");
        }
    }
}
