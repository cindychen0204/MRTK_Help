using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour
{

    public Button SaveButton;
    public Button LoadButton;
    public const string PlayerPath = "Prefabs/AddedCube";
    private static int Count = 0;


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


    private void Start()
    {
        Count = 0;
        SaveData.Load(dataPath());


        //Create xml file at first place
        if (!System.IO.File.Exists(dataPath()))
        {

            var stream = new FileStream(dataPath(), FileMode.Create);

        }
    }

    /// <summary>
    /// Create gameObject by data
    /// </summary>
    /// <param name="data">ActorData</param>
    /// <param name="path">path to prefab</param>
    /// <param name="position">saved prefab position</param>
    /// <param name="rotation">saved prefab rotation</param>
    /// <returns></returns>
    public static PrefabActor CreateActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = GameObject.Instantiate(prefab, position, rotation) as GameObject;

        PrefabActor prefabActor = go.GetComponent<PrefabActor>() ?? go.AddComponent<PrefabActor>();

        prefabActor.data = data;

        go.name += Count;

        Count++;

        return prefabActor;
    }
}
