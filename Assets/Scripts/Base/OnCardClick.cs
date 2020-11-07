using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnCardClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject playDeckCard1;
    [SerializeField] GameObject playDeckCard2;
    [SerializeField] GameObject playDeckCard3;

    public int cardSelected;

    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;

    void Awake()
    {
        // Get both of the components we need to do this
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    public void OnPointerDown(PointerEventData pointerData)
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);


                if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard1)
                {
                    cardSelected = 1;
                }
                else if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard2)
                {
                    cardSelected = 2;
                }
                else if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard3)
                {
                    cardSelected = 3;
                }
            }
        }
    }
}