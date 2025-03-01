using UnityEngine;

namespace MFramework.Extensions.UnityComponent
{
    public static class RectTransformExpansions
    {
        public static void SetAnchor(this RectTransform source, AnchorPresets anchorPreset, int offsetX = 0,
            int offsetY = 0) {
            source.anchoredPosition = new Vector3(offsetX, offsetY, 0);

            switch (anchorPreset) {
                case (AnchorPresets.TopLeft): {
                    source.anchorMin = new Vector2(0, 1);
                    source.anchorMax = new Vector2(0, 1);
                    source.SetPivot(PivotPresets.TopLeft);
                    break;
                }
                case (AnchorPresets.TopCenter): {
                    source.anchorMin = new Vector2(0.5f, 1);
                    source.anchorMax = new Vector2(0.5f, 1);
                    source.SetPivot(PivotPresets.TopCenter);
                    break;
                }
                case (AnchorPresets.TopRight): {
                    source.anchorMin = new Vector2(1, 1);
                    source.anchorMax = new Vector2(1, 1);
                    source.SetPivot(PivotPresets.TopRight);
                    break;
                }

                case (AnchorPresets.MiddleLeft): {
                    source.anchorMin = new Vector2(0, 0.5f);
                    source.anchorMax = new Vector2(0, 0.5f);
                    source.SetPivot(PivotPresets.MiddleLeft);
                    break;
                }
                case (AnchorPresets.MiddleCenter): {
                    source.anchorMin = new Vector2(0.5f, 0.5f);
                    source.anchorMax = new Vector2(0.5f, 0.5f);
                    source.SetPivot(PivotPresets.MiddleCenter);
                    break;
                }
                case (AnchorPresets.MiddleRight): {
                    source.anchorMin = new Vector2(1, 0.5f);
                    source.anchorMax = new Vector2(1, 0.5f);
                    source.SetPivot(PivotPresets.MiddleRight);
                    break;
                }

                case (AnchorPresets.BottomLeft): {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(0, 0);
                    source.SetPivot(PivotPresets.BottomLeft);
                    break;
                }
                case (AnchorPresets.BottomCenter): {
                    source.anchorMin = new Vector2(0.5f, 0);
                    source.anchorMax = new Vector2(0.5f, 0);
                    source.SetPivot(PivotPresets.BottomCenter);
                    break;
                }
                case (AnchorPresets.BottomRight): {
                    source.anchorMin = new Vector2(1, 0);
                    source.anchorMax = new Vector2(1, 0);
                    source.SetPivot(PivotPresets.BottomRight);
                    break;
                }

                case (AnchorPresets.HorStretchTop): {
                    source.anchorMin = new Vector2(0, 1);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }
                case (AnchorPresets.HorStretchMiddle): {
                    source.anchorMin = new Vector2(0, 0.5f);
                    source.anchorMax = new Vector2(1, 0.5f);
                    break;
                }
                case (AnchorPresets.HorStretchBottom): {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(1, 0);
                    break;
                }

                case (AnchorPresets.VertStretchLeft): {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(0, 1);
                    break;
                }
                case (AnchorPresets.VertStretchCenter): {
                    source.anchorMin = new Vector2(0.5f, 0);
                    source.anchorMax = new Vector2(0.5f, 1);
                    break;
                }
                case (AnchorPresets.VertStretchRight): {
                    source.anchorMin = new Vector2(1, 0);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }

                case (AnchorPresets.StretchAll): {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(1, 1);
                    source.offsetMax = Vector2.zero;
                    source.offsetMin = Vector2.zero;
                    break;
                }
            }
        }

        public static void SetPivot(this RectTransform source, PivotPresets preset) {
            switch (preset) {
                case (PivotPresets.TopLeft): {
                    source.pivot = new Vector2(0, 1);
                    break;
                }
                case (PivotPresets.TopCenter): {
                    source.pivot = new Vector2(0.5f, 1);
                    break;
                }
                case (PivotPresets.TopRight): {
                    source.pivot = new Vector2(1, 1);
                    break;
                }

                case (PivotPresets.MiddleLeft): {
                    source.pivot = new Vector2(0, 0.5f);
                    break;
                }
                case (PivotPresets.MiddleCenter): {
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
                }
                case (PivotPresets.MiddleRight): {
                    source.pivot = new Vector2(1, 0.5f);
                    break;
                }

                case (PivotPresets.BottomLeft): {
                    source.pivot = new Vector2(0, 0);
                    break;
                }
                case (PivotPresets.BottomCenter): {
                    source.pivot = new Vector2(0.5f, 0);
                    break;
                }
                case (PivotPresets.BottomRight): {
                    source.pivot = new Vector2(1, 0);
                    break;
                }
            }
        }
    }
}