using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour {

    public Button saveButton;
    public Button loadButton;
    public const string playerPath = "Prefabs/AddedCube";
    public static int count = 0;


    private string dataPath()
    {
        string temp = string.Empty;

#if WINDOWS_UWP
            // HoloLens、LocalAppData/AppName/LocalStateフォルダを参照する
            temp = Windows.Storage.ApplicationData.Current.LocalFolder.Path + "/actors.xml";
#else
        
        temp = System.IO.Path.Combine(Application.dataPath, "Data/actors.xml");
#endif
        return temp;
    }

    /// <summary>
    /// Old version
    /// </summary>
    //void Awake()
    //{


    //}

    private void Start()
    {
        //CreateActor(playerPath, new Vector3(0, 1.6f, 0), Quaternion.identity);
        //CreateActor(playerPath, new Vector3(5, 1.6f, 0), Quaternion.identity);
        //CreateActor(playerPath, new Vector3(-5, 1.6f, 0), Quaternion.identity);
        count = 0;
        SaveData.Load(dataPath());

        if (!System.IO.File.Exists(dataPath()))
        {

            FileStream stream = new FileStream(dataPath(), FileMode.Create);

        }
    }

    public static Actor CreateActor(string path, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = GameObject.Instantiate(prefab, position, rotation) as GameObject;

        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();

        go.name += count;

        count++;

        return actor;
    }

    public static Actor CreateActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = GameObject.Instantiate(prefab, position, rotation) as GameObject;

        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();

        actor.data = data;

        go.name += count;

        count++;

        return actor;
    }

    void OnEnable()
    {
        saveButton.onClick.AddListener(delegate { SaveData.Save(dataPath(), SaveData.actorContainer); });
        loadButton.onClick.AddListener(delegate { SaveData.Load(dataPath()); });
    }
    void OnDisable()
    {
        saveButton.onClick.RemoveListener(delegate { SaveData.Save(dataPath(), SaveData.actorContainer); });
        loadButton.onClick.RemoveListener(delegate { SaveData.Load(dataPath()); });
    }
}
