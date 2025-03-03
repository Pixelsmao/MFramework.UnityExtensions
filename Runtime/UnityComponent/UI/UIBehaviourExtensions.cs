using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MFramework.Extensions.UnityComponent
{
    public static class UIBehaviourExtensions
    {
        // public static void AddPointerEvent(this UIBehaviour self, PointerEventType eventType, Action action) {
        //     self.transform.GetOrAddComponent<PointerEventController>().AddPointerEvent(eventType, action);
        // }
        //
        // private static Vector3 moveOffset;
        //
        // public static void PointerDrag(this UIBehaviour self) {
        //     self.AddPointerEvent(PointerEventType.PointerDown,
        //         () => { moveOffset = Input.mousePosition - self.transform.position; });
        //     self.AddPointerEvent(PointerEventType.Drag,
        //         () => { self.transform.position = Input.mousePosition - moveOffset; });
        // }
        //
        // private static Vector3 defaultScaleValue;
        //
        // public static void PointerEnters(this Image self, Vector3 zoomValue, float duration,
        //     float depthMoveValue = 0.0f, AudioClip sound = null, Sprite sprite = null) {
        //     defaultScaleValue = self.transform.localScale;
        //     self.AddPointerEvent(PointerEventType.PointerEnter, () =>
        //     {
        //         //TODO 空检查
        //         self.transform.DOScale(zoomValue, duration);
        //         self.transform.DOLocalMoveZ(depthMoveValue, duration);
        //         if (sound != null) {
        //         }
        //
        //         if (sprite != null) self.sprite = sprite;
        //     });
        //     self.AddPointerEvent(PointerEventType.PointerExit, () =>
        //     {
        //         self.transform.DOScale(defaultScaleValue, duration);
        //         self.transform.DOLocalMoveZ(0, duration);
        //     });
        // }
        //
        // //TODO 空检查和格式优化，音频播放
        // public static void PointerClick(this Image self, AudioClip sound = null, Sprite sprite = null) {
        //     self.AddPointerEvent(PointerEventType.PointerClick, () =>
        //     {
        //         if (sound != null) {
        //         }
        //
        //         if (sprite != null) self.sprite = sprite;
        //     });
        // }
        //
        // //TODO 空检查和格式优化，音频播放
        // public static void PointerPress(this Image self, AudioClip sound = null, Sprite sprite = null) {
        //     self.AddPointerEvent(PointerEventType.PointerDown, (() =>
        //     {
        //         if (sound != null) {
        //         }
        //
        //         if (sprite != null) self.sprite = sprite;
        //     }));
        // }

        public static T GetDefaultSprite<T>(this UIBehaviour self,string name) where T : Object {
            T[] objs = Resources.FindObjectsOfTypeAll<T>();
            if (objs != null && objs.Length > 0) {
                foreach (T obj in objs) {
                    if (obj.name == name)
                        return obj;
                }
            }

            objs = AssetBundle.FindObjectsOfType<T>();
            if (objs != null && objs.Length > 0) {
                foreach (T obj in objs) {
                    if (obj.name == name)
                        return obj;
                }
            }

            return default(T);
        }

        public static GameObject CreateChildText(Transform parent, string textContent = "Text Content") {
            GameObject childTextGameObject = new GameObject() { name = "Text", layer = 5 };
            RectTransform childRectTransform = childTextGameObject.AddComponent<RectTransform>();
            childRectTransform.SetAnchor(AnchorPresets.StretchAll);
            childRectTransform.SetParent(parent, false);
            Text text = childTextGameObject.AddComponent<Text>();
            text.alignment = TextAnchor.MiddleCenter;
            text.text = textContent;
            text.color = Color.black;
            return childTextGameObject;
        }
    }
}