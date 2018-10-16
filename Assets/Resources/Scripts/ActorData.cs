using System.Xml.Serialization;

public class ActorData
{
    [XmlAttribute("Name")]
    public string Name;

    [XmlElement("PosX")]
    public float PosX;

    [XmlElement("PosY")]
    public float PosY;

    [XmlElement("PosZ")]
    public float PosZ;

}