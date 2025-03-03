using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFramework.Extensions.UnityComponent
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns the full hierarchy name of the gameObject.
        /// </summary>
        /// <param name="self">self</param>
        public static string GetFullName(this GameObject self)
        {
            return self.transform.GetFullName();
        }

        /// <summary>
        /// Convert the Transform of the UI layer object to RectTransform.
        /// </summary>
        /// <param name="self">self</param>
        /// <returns></returns>
        public static RectTransform ToRectTransform(this GameObject self)
        {
            return self.transform.ToRectTransform();
        }

        /// <summary>
        /// Get all child objects transform
        /// </summary>
        /// <param name="self">self</param>
        /// <returns></returns>
        public static List<Transform> GetAllChildren(this GameObject self)
        {
            return self.transform.GetAllChildren();
        }


        /// <summary>
        /// Get transforms according to whether the child object is activated.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activeInHierarchy">need activity</param>
        /// <returns></returns>
        public static List<Transform> GetTransformsByActivated(this GameObject self, bool activeInHierarchy)
        {
            return self.transform.GetTransformsByActivated(activeInHierarchy);
        }

        /// <summary>
        /// Get transforms according to whether the child object has a component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="haveComponent">Have component</param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static List<Transform> GetTransformsByContainComponent<T>(this GameObject self, bool haveComponent)
            where T : Component
        {
            return self.transform.GetTransformsByContainComponent<T>(haveComponent);
        }

        /// <summary>
        /// Get transforms according to whether the child object satisfies the condition.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="activeInHierarchy"></param>
        /// <param name="haveComponent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<Transform> GetTransformsByCondition<T>(this GameObject self, bool activeInHierarchy,
            bool haveComponent) where T : Component
        {
            return self.transform.GetTransformsByCondition<T>(activeInHierarchy, haveComponent);
        }

        /// <summary>
        /// Get gameObjects according to whether the child object is activated.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activeInHierarchy">need activity</param>
        /// <returns></returns>
        public static List<GameObject> GetGameObjectsByActivated<T>(this GameObject self, bool activeInHierarchy)
            where T : Component
        {
            return self.transform.GetGameObjectsByActivated(activeInHierarchy);
        }

        /// <summary>
        /// Get gameObjects according to whether the child object has a component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="haveComponent">Have component</param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static List<GameObject> GetGameObjectsByContainComponent<T>(this GameObject self, bool haveComponent)
            where T : Component
        {
            return self.transform.GetGameObjectsByContainComponent<T>(haveComponent);
        }

        /// <summary>
        /// Destroy gameObjects according to whether the child object has a component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="haveComponent">Have component</param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static void DestroyGameObjectsByContainComponent<T>(this GameObject self, bool haveComponent)
            where T : Component
        {
            self.transform.DestroyGameObjectsByContainComponent<T>(haveComponent);
        }

        /// <summary>
        /// Destroy gameObjects according to whether the child object is activated.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activeInHierarchy">need activity</param>
        /// <returns></returns>
        public static void DestroyGameObjectsByActivated(this GameObject self, bool activated)
        {
            self.transform.DestroyGameObjectsByActivated(activated);
        }

        /// <summary>
        /// Destroy gameObjects according to whether the child object satisfies the condition.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="activeInHierarchy"></param>
        /// <param name="haveComponent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void DestroyGameObjectsByCondition<T>(this GameObject self, bool activated, bool haveComponent)
            where T : Component
        {
            self.transform.DestroyGameObjectsByCondition<T>(activated, haveComponent);
        }

        /// <summary>
        /// destroy all child objects
        /// </summary>
        /// <param name="self">this</param>
        public static void DestroyAllChildren(this GameObject self)
        {
            self.transform.DestroyAllChildren();
        }

        /// <summary>
        /// disable active all child objects
        /// </summary>
        /// <param name="self">this</param>
        public static void DisActiveAllChildren(this GameObject self)
        {
            self.transform.DisActiveAllChildren();
        }

        /// <summary>
        /// enable active all child objects
        /// </summary>
        /// <param name="self">this</param>
        public static void ActiveAllChildren(this GameObject self)
        {
            self.transform.ActiveAllChildren();
        }

        /// <summary>
        /// Determine whether gameObject has component.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static bool HaveComponent<T>(this GameObject self) where T : Component
        {
            return self.transform.HaveComponent<T>();
        }


        /// <summary>
        /// Determine whether gameObject has component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="component"></param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static bool HaveComponent<T>(this GameObject self, out T component) where T : Component
        {
            return self.transform.HaveComponent<T>(out component);
        }

        /// <summary>
        /// Get or add component.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            return self.transform.GetOrAddComponent<T>();
        }
    }
}