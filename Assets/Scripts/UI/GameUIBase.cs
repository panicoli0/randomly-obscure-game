using UnityEngine;

namespace CardMatchingGame.UI
{
    public class GameUIBase : MonoBehaviour
    {
        internal void MenuToggle(bool display) => gameObject.SetActive(display);
    }
}