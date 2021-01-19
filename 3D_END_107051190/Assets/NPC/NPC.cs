using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC Data")]
    public NPC_sigletons Data;
    [Header("dialoug")]
    public GameObject dialougBox;
    [Header("dialougText")]
    public Text textContent;
    [Header("NPC_Name")]
    public Text textName;
    [Header("waintSc")]
    public float interval = 0.2f;
    
    
    bool IsDone;
    bool IsFPress;
    bool InStay;
    
    public bool InArea;
    Animator NPC_anim;
    private void Awake()
    {
        NPC_anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if ( InStay && IsDone)
            {

                StartCoroutine(Dialoug(2));
                IsDone = false;


            }
        }
        else
        {
            IsFPress = false;
        }
        
    }

    public enum NPCstate
    {
        First, takeGun, Finish
    }
    public NPCstate state = NPCstate.First;


    /**
    private void Start()
    {
        StartCoroutine(test());
    }

    private IEnumerator test ()
    {
        print("before 1.5s");
        yield return new WaitForSeconds(1.5f);
        print("after 1.5s");
        
    }
    **/

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            InArea = true;
            NPC_anim.SetBool("IsTalking", true);
            StartCoroutine(Dialoug(1));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            InStay = true;
        }
        else
        {
            InStay = false;
        }
       
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")

        {
            InArea = false;
            NPC_anim.SetBool("IsTalking", false);
            stopDialoug();
        }
    }
    private void stopDialoug()
    {
        dialougBox.SetActive(false);
        StopAllCoroutines();
    }


    private IEnumerator Dialoug(int num)
    {
        dialougBox.SetActive(true);
        textContent.text = "";
        textName.text = name + ":";

        string dialougStr = null;
        if (num == 1)
        {
            dialougStr = Data.textA;
        }
        if (num == 2)
        {
            dialougStr = Data.textB;
        }

       
        for (int i = 0; i < dialougStr.Length; i++)
        {
            textContent.text += dialougStr[i] + "";

            yield return new WaitForSeconds(interval);
        }
        IsDone = true;

    }
}
