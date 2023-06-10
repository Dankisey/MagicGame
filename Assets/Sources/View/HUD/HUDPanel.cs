using UnityEngine;

public class HUDPanel : MonoBehaviour
{
    [SerializeField] private HUDPanel[] _toCloseOnOpen;
    [SerializeField] private HUDPanel[] _toOpenOnClose;

    public void TurnOn()
    {
        foreach(var panel in _toCloseOnOpen)
            panel.TurnOff();

        gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        foreach (var panel in _toOpenOnClose)
            panel.TurnOn();

        gameObject.SetActive(false);
    }
}