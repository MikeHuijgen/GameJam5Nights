using UnityEngine;
using UnityEngine.UI;

public class ColorChangeCrossHair : MonoBehaviour
{
    [SerializeField] private Image crossHair;

    [SerializeField] Outline outline;
    [SerializeField] LayerMask LayerDoor;
    private void Start()
    {
        crossHair.color = new Color(1, 1, 1, 0.75f);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f, LayerDoor))
        {
                crossHair.color = new Color(1, 0, 0, 0.75f);
                outline.enabled = true;
                Debug.Log("door");
        }
        else
        {
            crossHair.color = new Color(1, 1, 1, 0.75f);
            outline.enabled = false;
            Debug.Log("door 2");
        }
    }
}