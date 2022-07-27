using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;
using System;



public class WS_CLIENT : MonoBehaviour
{
    Text textField;
    WebSocket ws;
    // Debug.Log("Text");
    private void Start()

    {   
        textField = GameObject.Find("Text").GetComponent<Text>();
        textField.text = "can i ask you a question?";
        Debug.Log("WHHWHW");
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from "+((WebSocket)sender).Url+", Data : "+e.Data);
            textField.text = e.Data;
            Console.WriteLine(e.Data);
            Console.WriteLine(e);
            Console.WriteLine("aaaaaaaaaaaaa");
            Debug.Log("Done");
            Debug.Log(e.Data.ToString());
            Debug.Log(e.Data);
        };
    }
private void Update()
    {
        if(ws == null)
        {
            return;
        }
    if (Input.GetKeyDown(KeyCode.Space))
            {
                ws.Send("Hello");
            }  
        }
} 