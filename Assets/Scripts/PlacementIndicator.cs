using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    void Start()
    {
        // Se obtienen los componentes
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // Se oculta el cursor
        visual.SetActive(false);
    }

    void Update()
    {
        // Se dispara un raycast al centro de la pantalla
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // Si se encuentra un plano de AR, se modifica la posición y rotación del cursor
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // Se vuelve a mostrar el cursor en caso de estar oculto
            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }                
        }
    }
}