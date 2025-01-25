using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonExtensions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    Button button;

    public GameObject[] highlightedObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach(GameObject obj in highlightedObjects)
        {
            obj.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach(GameObject obj in highlightedObjects)
        {
            obj.SetActive(false);
        }
    }
}
