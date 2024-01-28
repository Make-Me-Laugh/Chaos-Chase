using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumChat : MonoBehaviour
{
    public GameObject chatBubble;

    List<string> mumDialogues = new List<string> {
        "Ah boy, go study!",
        "I will cut fruits for you.",
        "Ah boy, remember to finish your homework.",
        "You have to study so that you can become a doctor or a lawyer.",
        "Your exam is around the corner..."
    };
    private int mumDialogueIndex = 0;
    private float time;
    private float interval = 12f;

    void Start()
    {
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        while (time >= interval)
        {
            showChat();
            time -= interval;
            mumDialogueIndex++;
            if (mumDialogueIndex > mumDialogues.Count)
            {
                mumDialogueIndex = 0;
            }
        }
    }

    private void showChat()
    {
        Vector3 position = transform.position + new Vector3(0f, 1f);
        GameObject instance = Instantiate(chatBubble, position, Quaternion.identity);
        instance.GetComponent<ChatBubble>().setText(mumDialogues[mumDialogueIndex]);
        Destroy(instance, 4f);
    }
}