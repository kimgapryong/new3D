using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Start_Ui : UI_Pop
{
   enum TextData
    {
        ButtonText,
        TestText,
    }
    enum ButtonData
    {
        TestButton,
    }
    enum ImageData
    {
        TestImage,
    }

    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        Bind<Text>(typeof(TextData));
        Bind<Button>(typeof(ButtonData));
        Bind<Image>(typeof(ImageData));
        Bind<GameObject>(typeof(ButtonData));

        Get<Text>((int)TextData.TestText).text = "¾Æ Á¹¶ó Èûµå³×";

        GameObject go = Get<Image>((int)ImageData.TestImage).gameObject;
        GameObject go2 = GetObj((int)ButtonData.TestButton);

        AddEvente(go, (PointerEventData data) => { go.transform.position = data.position; }, UIEvent.UIMode.Click);
        AddEvente(go2, (PointerEventData data) => { go2.transform.position = data.position; }, UIEvent.UIMode.Drag);
    }
}
