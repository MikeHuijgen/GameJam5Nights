using UnityEngine;
using UnityEngine.UI;

public class ColorChangeCrossHair : MonoBehaviour
{
    [SerializeField] private Image crossHair;

    [SerializeField] Outline outline;

    private void Start()
    {
        crossHair.color = new Color(1, 1, 1, 0.75f);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f))
        {
            if (hit.transform.gameObject.CompareTag("Door"))
            {
                crossHair.color = new Color(1, 0, 0, 0.75f);
                outline.enabled = true;
            }
        }
        else
        {
            crossHair.color = new Color(1, 1, 1, 0.75f);
            outline.enabled = false; 
        }
    }
}