using System;
using System.Threading.Tasks;

namespace MFramework.Extensions.DataType
{
    public static class BoolExtensions
    {
        // 将bool转换为整型
        public static int ToInt(this bool value) {
            return value ? 1 : 0;
        }

        /// <summary>
        /// 将bool转换为Yes/No字符串
        /// </summary>
        public static string ToYesNo(this bool value) {
            return value ? "Yes" : "No";
        }

        /// <summary>
        /// 将bool转换为开/关字符串
        /// </summary>
        public static string ToOnOff(this bool value) {
            return value ? "On" : "Off";
        }


        /// <summary>
        /// 布尔值取反
        /// </summary>
        public static bool Toggle(this bool value) {
            return !value;
        }

        /// <summary>
        /// 返回"是""否"中文字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringInChinese(this bool value) {
            return value ? "是" : "否";
        }


        /// <summary>
        /// 根据布尔值的真伪执行不同的动作，并返回布尔值本身。
        /// </summary>
        /// <param name="self">布尔值</param>
        /// <param name="actionIfTrue">如果布尔值为真要执行的动作</param>
        /// <param name="actionIfFalse">如果布尔值为假要执行的动作</param>
        /// <returns>布尔值本身</returns>
        public static bool Execute(this bool self, Action actionIfTrue, Action actionIfFalse) {
            if (self) actionIfTrue();
            else actionIfFalse();
            return self;
        }

        /// <summary>
        /// 如果布尔值为真，则执行指定的动作，并返回布尔值本身。
        /// </summary>
        /// <param name="self">布尔值</param>
        /// <param name="action">要执行的动作</param>
        /// <returns>布尔值本身</returns>
        public static bool ExecuteTrue(this bool self, Action action) {
            if (self) action();
            return self;
        }

        /// <summary>
        /// 如果布尔值为真，则执行指定的动作，并传递布尔值本身作为参数，返回布尔值本身。
        /// </summary>
        /// <param name="self">布尔值</param>
        /// <param name="action">要执行的动作，参数为布尔值本身</param>
        /// <returns>布尔值本身</returns>
        public static bool ExecuteTrue(this bool self, Action<bool> action) {
            if (self) action(self);
            return self;
        }

        /// <summary>
        /// 如果布尔值为假，则执行指定的动作，并返回布尔值本身。
        /// </summary>
        /// <param name="self">布尔值</param>
        /// <param name="action">要执行的动作</param>
        /// <returns>布尔值本身</param>
        public static bool ExecuteFalse(this bool self, Action action) {
            if (!self) action();
            return self;
        }

        /// <summary>
        /// 如果布尔值为假，则执行指定的动作，返回布尔值本身。
        /// </summary>
        /// <param name="self">布尔值</param>
        /// <param name="action">要执行的动作，参数为布尔值本身</param>
        /// <returns>布尔值本身</returns>
        public static bool ExecuteFalse(this bool self, Action<bool> action) {
            if (self == false) action(self);
            return self;
        }

        public static T Select<T>(this bool self, T trueValue, T falseValue) {
            return self ? trueValue : falseValue;
        }

        public static bool? ToNullable(this bool self) {
            return (bool?)self;
        }

        public static bool Validate(this bool self, Func<bool, bool> validator, Action onFailure) {
            if (!validator(self)) {
                onFailure();
            }

            return self;
        }

        public static async Task<bool> ExecuteAsync(this bool self, Func<Task> action) {
            if (self) {
                await action();
            }

            return self;
        }

        public static async Task<bool> ExecuteAsync(this bool self, Func<Task> actionIfTrue, Func<Task> actionIfFalse) {
            if (self) {
                await actionIfTrue();
            }
            else {
                await actionIfFalse();
            }

            return self;
        }
    }
}