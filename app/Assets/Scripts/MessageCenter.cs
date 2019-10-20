using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class MessageCenter : MonoBehaviour
{
    public Text MessageTextCompontent { get; set; }

    public static Queue<Message> Messages { get; } = new Queue<Message>();

    public static float SecondsOfShowing = 3;
    public static float? SecondsOfAnimate = 0.5F;
    public static float? EndOfShowing;

    public static Message ShowingNow { get; set; }

    void Start()
    {
        MessageTextCompontent = GameObject.Find("MessageText").GetComponent<Text>();

        Show("Test 1", "https://google.com?q=A1");
        Show("Test 2", "https://google.com?q=A2");
        Show("Test 3", "https://google.com?q=A3");
        Show("Test 4", "https://google.com?q=A4");
    }

    public static void Show(string text, string url = null)
    {
        Messages.Enqueue(new Message
        {
            Text = text, 
            Link = url
        });
    }

    public void OpenLink()
    {
        if (ShowingNow?.Link != null)
        {
            Application.OpenURL(ShowingNow.Link);
        }
    }

    public void CloseMessage()
    {
        if (EndOfShowing.HasValue)
        {
            EndOfShowing = Time.time + SecondsOfAnimate ?? 0;
        }
    }

    void Update()
    {
        if (EndOfShowing.HasValue)
        {
            if (EndOfShowing.Value <= Time.time)
            {
                MessageTextCompontent.text = "";
                MessageTextCompontent.color.Opacity(0);
                EndOfShowing = null;
                ShowingNow = null;
            }
            else
            {
                var time = Time.time;
                var opacity = Math.Min(EndOfShowing.Value - time, time - (EndOfShowing.Value - SecondsOfShowing)) / SecondsOfAnimate ?? 1;
                opacity = Math.Min(Math.Max(opacity, 0), 1F);
                MessageTextCompontent.color = MessageTextCompontent.color.Opacity(opacity);
            }
        }

        if (!EndOfShowing.HasValue && Messages.Count > 0)
        {
            var message = Messages.Dequeue();
            MessageTextCompontent.text = message.Text;
            EndOfShowing = Time.time + SecondsOfShowing;
            ShowingNow = message;
        }
    }
}