using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class OnCardClick : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    [SerializeField] GameObject playDeckCard1;
    [SerializeField] GameObject playDeckCard2;
    [SerializeField] GameObject playDeckCard3;

    [SerializeField] GameObject cardSelected1;
    [SerializeField] GameObject cardSelected2;
    [SerializeField] GameObject cardSelected3;

    [SerializeField] GameObject cardHovered1;
    [SerializeField] GameObject cardHovered2;
    [SerializeField] GameObject cardHovered3;

    public int cardSelected;

    public static event Action CardHoveredOver;
    public static event Action CardClicked;

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
                    CardClicked?.Invoke();

                    cardSelected1.SetActive(true);
                    cardSelected2.SetActive(false);
                    cardSelected3.SetActive(false);
                }
                else if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard2)
                {
                    cardSelected = 2;
                    CardClicked?.Invoke();

                    cardSelected1.SetActive(false);
                    cardSelected2.SetActive(true);
                    cardSelected3.SetActive(false);
                }
                else if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard3)
                {
                    cardSelected = 3;
                    CardClicked?.Invoke();

                    cardSelected1.SetActive(false);
                    cardSelected2.SetActive(false);
                    cardSelected3.SetActive(true);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData pointerData)
    {
        //Set up the new Pointer Event
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        pointerData.position = Input.mousePosition;
        this.raycaster.Raycast(pointerData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            Debug.Log("Entered " + result.gameObject.name);

            if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard1)
            {
                CardHoveredOver?.Invoke();

                cardHovered1.SetActive(true);
                cardHovered2.SetActive(false);
                cardHovered3.SetActive(false);

                if (cardSelected == 1)
                {
                    cardHovered1.SetActive(false);
                }
            }
            else if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard2)
            {
                CardHoveredOver?.Invoke();

                cardHovered2.SetActive(true);
                cardHovered1.SetActive(false);
                cardHovered3.SetActive(false);

                if (cardSelected == 2)
                {
                    cardHovered2.SetActive(false);
                }
            }
            else if (pointerData.pointerCurrentRaycast.gameObject == playDeckCard3)
            {
                CardHoveredOver?.Invoke();

                cardHovered3.SetActive(true);
                cardHovered1.SetActive(false);
                cardHovered2.SetActive(false);

                if (cardSelected == 3)
                {
                    cardHovered3.SetActive(false);
                }
            }
        }
    }
}