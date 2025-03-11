using System.Collections;
using System.Collections.Generic;
using MFramework;
using UnityEngine;

public static class ScreenSnapManager
{
    public static void CaptureScreenshot(string fileName) {
        ScreenCapture.CaptureScreenshot(fileName);
    }

    public static void CaptureScreenshot(string fileName, int superSize) {
        ScreenCapture.CaptureScreenshot(fileName, superSize);
    }

    public static void CaptureScreenshot(string fileName, ScreenCapture.StereoScreenCaptureMode captureMode) {
        ScreenCapture.CaptureScreenshot(fileName, captureMode);
    }

    public static Texture2D CaptureScreenshotAsTexture() {
        return ScreenCapture.CaptureScreenshotAsTexture();
    }

    public static Texture2D CaptureScreenshotAsTexture(ScreenCapture.StereoScreenCaptureMode captureMode) {
        return ScreenCapture.CaptureScreenshotAsTexture(captureMode);
    }

    public static void CaptureScreenshotIntoRenderTexture(RenderTexture renderTexture) {
        ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);
    }

    /// <summary>
    /// Clip part of the Texture2D according to the range of the clippingArea, and return the Texture2D in the clippingArea.
    /// 
    /// </summary>
    /// <param name="source">source Texture2D </param>
    /// <param name="clippingArea">clipping area</param>
    /// <returns></returns>
    public static Texture2D ClippingTexture2D(Texture2D source, RectTransform clippingArea) {
        // Get the RectTransform's position and size in pixels
        Vector2 rectPosition = clippingArea.position;
        Vector2 rectSize = clippingArea.rect.size;
        // Calculate the coordinates of the top-left corner of the cropping region
        int startX = Mathf.FloorToInt(rectPosition.x - rectSize.x / 2f);
        int startY = Mathf.FloorToInt(rectPosition.y - rectSize.y / 2f);

        // Ensure the start coordinates are within the texture bounds
        startX = Mathf.Clamp(startX, 0, source.width);
        startY = Mathf.Clamp(startY, 0, source.height);

        // Calculate the width and height of the cropping region
        int width = Mathf.FloorToInt(rectSize.x);
        int height = Mathf.FloorToInt(rectSize.y);

        // Ensure the cropping region is within the texture bounds
        width = Mathf.Clamp(width, 0, source.width - startX);
        height = Mathf.Clamp(height, 0, source.height - startY);

        // Create a new texture with the size of the cropping region
        Texture2D croppedTexture = new Texture2D(width, height);


        // Copy pixels from the original texture within the cropping region
        Color[] originalPixels = source.GetPixels(startX, startY, width, height);
        croppedTexture.SetPixels(originalPixels);
        croppedTexture.Apply();
        return croppedTexture;
    }
}