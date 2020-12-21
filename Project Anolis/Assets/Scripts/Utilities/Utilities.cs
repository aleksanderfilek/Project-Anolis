using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

namespace Utilities
{
    public static class Timer
    {
        private static List<float> _timer = new List<float>();

        public static int StartTimer()
        {
            var index = -1;
            for (var i = 0; i < _timer.Count; i++)
            {
                if (_timer[i] > 0.0f) continue;
                index = i;
                break;
            }

            if (index == -1)
            {
                _timer.Add(0.0f);
                index = _timer.Count - 1;
            }

            var time = Time.realtimeSinceStartup;

            _timer[index] = time;

            return _timer.Count - 1;
        }

        public static float StopTimer(int index)
        {
            var startTime = _timer[index];
            _timer[index] = 0.0f;
            var time = Time.realtimeSinceStartup - startTime;
            return time;
        }

        public static void PrintAndStopTimer(int index)
        {
            Debug.Log(StopTimer(index) + "s");
        }
    }

    public static class Object
    {
        public static Transform[] GetChilds(Transform transform)
        {
            
            Transform[] array = null;

            int length = transform.childCount;
            if (length > 0)
            {
                array = new Transform[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = transform.GetChild(i);
                }
            }
            
            return array;
        }
    }
    
}
