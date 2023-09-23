﻿using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Event_Bus
{
    public class EventBus : IService
    {
        private Dictionary<string, List<object>> _signalCallbacks;

        public void Subscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;

            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Add(callback);
            }
            else
            {
                _signalCallbacks.Add(key, new List<object>() {callback});
            }
        }

        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;

            if (_signalCallbacks.ContainsKey(key))
            {
                foreach (KeyValuePair<string, List<object>> obj in _signalCallbacks)
                {
                    var callback = obj as Action<T>;
                    callback?.Invoke(signal);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Remove(callback);
            }
            else
            {
                Debug.LogErrorFormat("Trying to unsubscribe for not existing key {0}", key);
            }
        }
    }
}