using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class MessageCenter : MonoBehaviour
{
    public Text MessageTextComponent { get; set; }
    public Text TitleTextComponent { get; set; }

    public static Queue<Message> Messages { get; } = new Queue<Message>();

    public static float SecondsOfShowing = 3;
    public static float? SecondsOfAnimate = 0.5F;
    public static float? EndOfShowing;

    public static Message ShowingNow { get; set; }

    void Start()
    {
        MessageTextComponent = GameObject.Find("MessageText").GetComponent<Text>();
        TitleTextComponent = GameObject.Find("TitleText").GetComponent<Text>();

//        Show(@"What is Lorem Ipsum?
//Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
//            "Title testing size and position",
//            url: "https://google.com?q=A1");
//        Show("Test 2", url: "https://google.com?q=A2");
//        Show("Test 3", url: "https://google.com?q=A3");
//        Show("Test 4", url: "https://google.com?q=A4");

        MessageTextComponent.text = "";
        TitleTextComponent.text = "";
    }

    public static void Show(string text, string title = null, string url = null)
    {
        Messages.Enqueue(new Message
        {
            Title = title,
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
                MessageTextComponent.text = "";
                TitleTextComponent.text = "";
                MessageTextComponent.color = MessageTextComponent.color.Opacity(0);
                TitleTextComponent.color = TitleTextComponent.color.Opacity(0);
                EndOfShowing = null;
                ShowingNow = null;
            }
            else
            {
                var time = Time.time;
                var opacity = Math.Min(EndOfShowing.Value - time, time - (EndOfShowing.Value - SecondsOfShowing)) / SecondsOfAnimate ?? 1;
                opacity = Math.Min(Math.Max(opacity, 0), 1F);
                MessageTextComponent.color = MessageTextComponent.color.Opacity(opacity);
                TitleTextComponent.color = TitleTextComponent.color.Opacity(opacity);
            }
        }

        if (!EndOfShowing.HasValue && Messages.Count > 0)
        {
            var message = Messages.Dequeue();
            MessageTextComponent.text = message.Text;
            TitleTextComponent.text = message.Title;
            EndOfShowing = Time.time + SecondsOfShowing;
            ShowingNow = message;
        }
    }
}