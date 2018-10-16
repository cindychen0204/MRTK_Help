using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CloneObject : MonoBehaviour, IInputClickHandler
{

    public GameObject original;

    private int count = 0;

    void Start() {
        count = 0;
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        Clone();
    }


    void Clone()
    {

        var clone = GameObject.Instantiate(original);
        clone.transform.parent = clone.transform.parent;
        clone.transform.position = new Vector3(0.0f, 0.0f, 2.0f);
        clone.transform.localScale = clone.transform.localScale;
        clone.name += count;
        count++;

    }

}

