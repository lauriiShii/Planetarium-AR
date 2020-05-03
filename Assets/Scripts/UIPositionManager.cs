using UnityEngine;
using UnityEngine.UI;

public class UIPositionManager : MonoBehaviour
{
    public Button buttonLeft;
    public Button buttonRight;
    public GameObject panelCenter;

    // Start is called before the first frame update
    void Start()
    {
        int widthScreen;
        RectTransform TransformButtonLeft = buttonLeft.GetComponent<RectTransform>();
        RectTransform TransformButtonRight = buttonRight.GetComponent<RectTransform>();
        RectTransform TransformPanelCenter = panelCenter.GetComponent<RectTransform>();

        // Se asigna el ancho de 100%
        widthScreen = Screen.width;

        // Posicionamos el boton izquierdo un 16,5% a la derecha manteniendo la altura
        TransformButtonLeft.position = new Vector2((widthScreen / 3) / 2, TransformButtonLeft.position.y);

        // Posicionamos el boton derecho un 16,5% a la izquierda manteniendo la altura
        TransformButtonRight.position = new Vector2((widthScreen - (widthScreen / 3) / 2), TransformButtonRight.position.y);

        // El area más oscura central debe ser un tercio de la pantalla siempre
        panelCenter.GetComponent<RectTransform>().sizeDelta = new Vector2(widthScreen / 3, TransformPanelCenter.rect.height);
        TransformPanelCenter.position = new Vector2((widthScreen / 2) - (panelCenter.GetComponent<RectTransform>().rect.width / 2), TransformPanelCenter.position.y);
    }
}
