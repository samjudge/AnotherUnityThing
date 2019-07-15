using UnityEngine;
using UnityEngine.UI;

public class ScrollingFadingTextBehaviourFactory : MonoBehaviour {

    [SerializeField]
    private ScrollingFadingTextBehaviour Prefab;
    [SerializeField]
    private Canvas MessageCanvasRoot;
    [SerializeField]
    private Camera BillboardFace;

    public ScrollingFadingTextBehaviour Make(string Message) {
        ScrollingFadingTextBehaviour prefab = Instantiate(Prefab);
        prefab.Message.text = Message;
        prefab.Message.rectTransform.SetParent(MessageCanvasRoot.transform);
        prefab.Message.rectTransform.localPosition = new Vector2(0, 0.25f);
        prefab.gameObject.GetComponent<Billboard>().SetFace(BillboardFace);
        return prefab;
    }
}
