using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] Inventory plInv;
    [SerializeField] ItemDatabase itemDatabase;

    [SerializeField] MessageAction introMessage;
    [SerializeField] Interactable interact;

    // Start is called before the first frame update
    void Start()
    {
        //clears the player's inventory and then adds the default items when starting a new game

        plInv.ClearInventory();

        plInv.AddItem(itemDatabase.GetItem(1));
        //plInv.AddItem(itemDatabase.GetItem(3));

        StartCoroutine(ShowIntroMessage());

        //DialogueSystem.Instance.InspectMessage(intro);

    }

    public void Interact()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainScene")
            introMessage.Act(); //show intro message
    }

    public void Lose()
    {
        interact.InspectActions[1].Act();
    }

    public void Win()
    {
        interact.InspectActions[2].Act();
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator ShowIntroMessage()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null; //delays the coroutine until mouse clicked
        }
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainScene")
            interact.InspectActions[0].Act();

    }

}
