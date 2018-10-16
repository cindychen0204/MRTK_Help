using UnityEngine;
using System.Xml.Serialization;
using System.IO;


public class SaveData
{

    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;


    public static void Load(string path)
    {
        if (System.IO.File.Exists(path) == true)
        {
            actorContainer = LoadActors(path);

            foreach (ActorData data in actorContainer.actors)
            {
                GameController.CreateActor(data, GameController.PlayerPath,
                    new Vector3(data.PosX, data.PosY, data.PosZ), Quaternion.identity);
            }

            OnLoaded();
        }
    }

    public static void Save(string path, ActorContainer actors)
    {

        OnBeforeSave();

        SaveActors(path, actors);

        Debug.Log(path);

        ClearActors();
    }

    public static void AddActorData(ActorData data)
    {
        actorContainer.actors.Add(data);
    }

    public static void ClearActors()
    {
        actorContainer.actors.Clear();
    }

    private static ActorContainer LoadActors(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ActorContainer));

        FileStream stream = new FileStream(path, FileMode.Open);

        ActorContainer actors = serializer.Deserialize(stream) as ActorContainer;

        

        stream.Dispose();

        return actors;
    }

    private static void SaveActors(string path, ActorContainer actors)
    {
        File.WriteAllText(path, "");

        XmlSerializer serializer = new XmlSerializer(typeof(ActorContainer));

        FileStream stream = new FileStream(path, FileMode.Truncate);

        serializer.Serialize(stream, actors);

       

        stream.Dispose();
    }

}
