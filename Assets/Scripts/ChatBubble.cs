using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ChatBubble : MonoBehaviour
{
    [SerializeField] SpriteRenderer Background;
    [SerializeField] TextMeshPro Text;

    public void setText(string text)
    {
        Text.SetText(text);
        Text.ForceMeshUpdate();
        Vector2 textSize = Text.GetRenderedValues(false);

        Vector2 padding = new Vector2(0.3f, 1f);
        Background.size = textSize + padding;
    }
}
