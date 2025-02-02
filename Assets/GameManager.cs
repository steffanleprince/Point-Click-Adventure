using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Inventory plInv;
    [SerializeField] ItemDatabase itemDatabase;

    [SerializeField] MessageAction introMessage;
    [SerializeField] Interactable interact;

    public GameObject loadingPanel;
    public GameObject pausePanel;
    public Toggle musicSwitch;

    PlayerScript pScript;

    // Start is called before the first frame update
    void Start()
    {
        //clears the player's inventory and then adds the default items when starting a new game

        plInv.ClearInventory();

        plInv.AddItem(itemDatabase.GetItem(1));
        //plInv.AddItem(itemDatabase.GetItem(3));

        StartCoroutine(ShowIntroMessage());

        //DialogueSystem.Instance.InspectMessage(intro);

        //neeeded to make the toggle functionality work properly
        musicSwitch.isOn = true;
        musicSwitch.isOn = false;

        pScript = PlayerScript.GetInstance();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
        }


    }

    public void Interact()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainScene")
            introMessage.Act(); //show intro message
    }


    public void AgainButton()
    {
        SceneManager.LoadScene("MainScene");
        
    }

    public void QuitButton()
    {
        Application.Quit();

    }


    IEnumerator ShowIntroMessage()
    {
        yield return new WaitForSeconds(2f);

        pScript.SwitchAction(); //seems to be needed to switch off walk/use and back again at start.
        pScript.SwitchAction();
        pScript.SwitchAction();
        pScript.SwitchAction();


        loadingPanel.SetActive(false);

        //while (!Input.GetMouseButtonDown(0))
        //{
        //    yield return null; //delays the coroutine until mouse clicked
        //}

        //Scene scene = SceneManager.GetActiveScene();

        //if (scene.name == "MainScene")

        //yield return new WaitForSeconds(1f);


        interact.InspectActions[0].Act();

    }

}
