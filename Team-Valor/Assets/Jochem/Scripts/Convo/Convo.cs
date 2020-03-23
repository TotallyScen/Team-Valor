using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Convo : MonoBehaviour
{
    public string[] conversation;
    public string[] conversationAnt1;
    public string[] conversationAnt2;
    public GameObject convoPanel;
    public Text conversationText;
    public Text conversationAnswer1;
    public Text conversationAnswer2;
    public bool convoRange;
    public int index;
    public GameObject player;
    public GameObject interactText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");          
    }

    // Update is called once per frame
    void Update()
    {
        if(convoRange == true)
        {
            
            if(Input.GetButtonDown("Interact"))
            {
                interactText.SetActive(false);
                ConvoStart();
            }
             // zet aan ui voor de f knop
        }
    }

    void OnTriggerEnter(Collider other)
    {
        convoRange = true;
        interactText.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        convoRange = false;
        interactText.SetActive(false);
    } 

    void ConvoStart()   
    {
        player.GetComponent<PlayerBehaviour>().moveAllow = false;
        conversationText.text = conversation[0];
        conversationAnswer1.text = conversationAnt1[0];
        conversationAnswer2.text = conversationAnt2[0];
        convoPanel.SetActive(true);
        index = 0;
    }
    
    public void TextUpdate(int i)
    {   
        index = index * 2 + i;
        if(index >= conversation.Length)
        {
            convoPanel.SetActive(false);
            player.GetComponent<PlayerBehaviour>().moveAllow = true;
        }
        else
        {   
            conversationText.text = conversation[index];
            conversationAnswer1.text = conversationAnt1[index];
            conversationAnswer2.text = conversationAnt2[index];
        }
    }
} 