using TMPro;
using UnityEngine;

public class LevelRequestView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelRequestUI;

    public void LevelRequest(int value)
    {
        _levelRequestUI.SetText("This level must be completed in les than: "+value.ToString());
    }
}
