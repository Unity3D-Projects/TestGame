﻿using UnityEngine;
using System.Collections;
using KBEngine;
using UnityEngine.UI;
using System;

public class UI_Game : MonoBehaviour {
    public InputField input_content;
    public Transform tran_text;
    public Scrollbar sb_vertical;
    public Text text_pos;
    public Transform tran_relive;

    private Text text_content;
	// Use this for initialization
	void Start () {
        text_content = tran_text.GetComponent<Text>();
        

        KBEngine.Event.registerOut("ReceiveChatMessage", this, "ReceiveChatMessage");
	}
	
	// Update is called once per frame
	void Update () {
        Entity avatar = KBEngineApp.app.player();
        if (avatar != null)
        {
            text_pos.text = "位置：" + avatar.position.x + "," + avatar.position.z;
        }
	}
    public void ReceiveChatMessage(string msg)
    {
        if (text_content.text.Length > 0)
        {
            text_content.text += "\n" + msg;
        }
        else
        {
            text_content.text += msg;
        }
        //;
        if (text_content.preferredHeight + 30 > 67)
            tran_text.GetComponent<RectTransform>().sizeDelta = new Vector2(0, text_content.preferredHeight);

        sb_vertical.value = 0;

       
    }
    public void OnSendMessage()
    {
        if (input_content.text.Length > 0)
            KBEngine.Event.fireIn("sendChatMessage", input_content.text);
    }
    public void OnRelive()
    {
        KBEngine.Event.fireIn("relive", (Byte)1);
    }
    public void OnCloseGame()
    {
        Application.Quit();
    }
}