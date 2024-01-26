using Events;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Events
{
    public delegate void VoidEvent();
    public delegate void FloatEvent(float _);
    public delegate void IntEvent(int _);
}

public class GlobalEvents
{
    public static VoidEvent GameOverEvent;
    public static VoidEvent StateChangeEvent;
    public class PlayerEvents
    {
        public static VoidEvent PlayerDeathEvent;
        public static IntEvent PlayerHealthChangeEvent;
    }

}