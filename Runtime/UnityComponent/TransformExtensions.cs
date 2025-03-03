using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MFramework.Extensions.UnityComponent
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Returns the full hierarchy name of the transform.
        /// </summary>
        public static string GetFullName(this Transform self)
        {
            string name = self.name;
            while (self.transform.parent != null)
            {
                self = self.transform.parent;
                name = self.name + "/" + name;
            }

            return name;
        }

        /// <summary>
        /// Convert the transform of the UI layer object to rectTransform.
        /// </summary>
        /// <param name="self">self</param>
        /// <returns></returns>
        public static RectTransform ToRectTransform(this Transform self)
        {
            if (self.gameObject.layer == 5)
                return self as RectTransform;
            Debug.LogError("Convert failed:This GameObject Layer is not UI Layer.");
            return default;
        }

        /// <summary>
        /// Get all child objects transforms
        /// </summary>
        /// <param name="self">self</param>
        /// <returns></returns>
        public static List<Transform> GetAllChildren(this Transform self)
        {
            List<Transform> transforms = new List<Transform>();
            var childCount = self.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                transforms.Add(self.GetChild(i).transform);
            }

            return transforms;
        }


        /// <summary>
        /// Get transforms according to whether the child object is activated.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activeInHierarchy">need activity</param>
        /// <returns></returns>
        public static List<Transform> GetTransformsByActivated(this Transform self, bool activeInHierarchy)
        {
            return self.GetAllChildren().Where(child => child.gameObject.activeInHierarchy.Equals(activeInHierarchy))
                .ToList();
        }

        /// <summary>
        /// Get transforms according to whether the child object has a component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="haveComponent">Have component</param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static List<Transform> GetTransformsByContainComponent<T>(this Transform self, bool haveComponent)
            where T : Component
        {
            return self.GetAllChildren().Where(child => child.HaveComponent<T>().Equals(haveComponent)).ToList();
        }

        /// <summary>
        /// Get transforms according to whether the child object satisfies the condition.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activeInHierarchy"></param>
        /// <param name="haveComponent"></param>
        /// <typeparam name="T"></typeparam>
        public static List<Transform> GetTransformsByCondition<T>(this Transform self, bool activeInHierarchy,
            bool haveComponent) where T : Component
        {
            return self.GetAllChildren().Where(child =>
                child.gameObject.activeInHierarchy.Equals(activeInHierarchy) &&
                child.HaveComponent<T>().Equals(haveComponent)).ToList();
        }

        /// <summary>
        /// Get gameObjects according to whether the child object is activated.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activeInHierarchy">need activity</param>
        /// <returns></returns>
        public static List<GameObject> GetGameObjectsByActivated(this Transform self, bool activeInHierarchy)
        {
            return (from child in self.GetAllChildren()
                where child.gameObject.activeInHierarchy.Equals(activeInHierarchy)
                select child.gameObject).ToList();
        }

        /// <summary>
        /// Get gameObjects according to whether the child object has a component.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="haveComponent">Have component</param>
        /// <typeparam name="T">T component</typeparam>
        public static List<GameObject> GetGameObjectsByContainComponent<T>(this Transform self, bool haveComponent)
            where T : Component
        {
            return (from child in self.GetAllChildren()
                where child.HaveComponent<T>().Equals(haveComponent)
                select child.gameObject).ToList();
        }

        /// <summary>
        /// Destroy gameObjects according to whether the child object has a component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="haveComponent">Have component</param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static void DestroyGameObjectsByContainComponent<T>(this Transform self, bool haveComponent)
            where T : Component
        {
            DestroyGameObjects(self.GetTransformsByContainComponent<T>(haveComponent));
        }

        /// <summary>
        /// Destroy gameObjects according to whether the child object is activated.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="activated"></param>
        /// <returns></returns>
        public static void DestroyGameObjectsByActivated(this Transform self, bool activated)
        {
            DestroyGameObjects(self.GetTransformsByActivated(activated));
        }

        /// <summary>
        /// Destroy gameObjects according to whether the child object satisfies the condition.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="activated"></param>
        /// <param name="haveComponent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void DestroyGameObjectsByCondition<T>(this Transform self, bool activated, bool haveComponent)
            where T : Component
        {
            DestroyGameObjects(self.GetTransformsByCondition<T>(activated, haveComponent));
        }

        /// <summary>
        /// destroy object
        /// </summary>
        /// <param name="transforms"></param>
        private static void DestroyGameObjects(List<Transform> transforms)
        {
            for (var i = 0; i < transforms.Count; i++)
            {
                Object.Destroy(transforms[i].gameObject);
            }

            Resources.UnloadUnusedAssets();
        }

        /// <summary>
        /// destroy all child objects
        /// </summary>
        /// <param name="self">this</param>
        public static void DestroyAllChildren(this Transform self)
        {
            for (var i = self.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(self.GetChild(i).gameObject);
            }

            Resources.UnloadUnusedAssets();
        }

        /// <summary>
        /// disable active all child objects
        /// </summary>
        /// <param name="self">this</param>
        public static void DisActiveAllChildren(this Transform self)
        {
            for (var i = self.childCount - 1; i >= 0; i--)
            {
                self.GetChild(i).gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// enable active all child objects
        /// </summary>
        /// <param name="self">this</param>
        public static void ActiveAllChildren(this Transform self)
        {
            for (var i = self.childCount - 1; i >= 0; i--)
            {
                self.GetChild(i).gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Determine whether transform has component.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static bool HaveComponent<T>(this Transform self) where T : Component
        {
            return self.TryGetComponent(typeof(T), out _);
        }


        /// <summary>
        /// Determine whether transform has component.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="component"></param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static bool HaveComponent<T>(this Transform self, out T component) where T : Component
        {
            bool result = self.TryGetComponent(typeof(T), out var targetComponent);
            component = targetComponent as T;
            return result;
        }

        /// <summary>
        /// Get or add component.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T">T component</typeparam>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this Transform self) where T : Component
        {
            if (self.HaveComponent<T>(out var component))
                return component;

            return self.gameObject.AddComponent<T>();
        }
    }
}