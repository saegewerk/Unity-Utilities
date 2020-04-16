using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityUtitlities {
    public class TouchInputDrag : MonoBehaviour {
        private RectTransform rect;
        public Vector2 input;
        public bool isDown;
        public Canvas canvas;
        public float sensitivity=1;
        private int count=-1;
        private Touch touch;
        void Start() {
            rect = GetComponent<RectTransform>();
        }

        public void OnPointerDown(BaseEventData bed) {
            PointerEventData ptr = (PointerEventData) bed;
            if (!isDown) {
                isDown = true;
                count = ptr.pointerId;
            }
        }
        public void OnPointerUp(BaseEventData bed) {
            PointerEventData ptr = (PointerEventData) bed;
            if (count==ptr.pointerId) {
                isDown = false;
                input =  Vector2.zero;
            }
        }

        public void OnDrag(BaseEventData bed) {
            PointerEventData ptr = (PointerEventData) bed;
            if (count == ptr.pointerId) {
                input = ptr.delta / canvas.scaleFactor * sensitivity;
                print(input);
            }
        }
    }
}