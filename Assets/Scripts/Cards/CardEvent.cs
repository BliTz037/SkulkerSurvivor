using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnClassCardUsedEvent : UnityEvent<float, float, float, float> { }

[System.Serializable]
public class OnSecondLifeBonusCardUsedEvent : UnityEvent<float> { }

[System.Serializable]
public class OnSoincBonusCardUsedEvent : UnityEvent<float> { }

[System.Serializable]
public class OnSlowCorruptionCardUsedEvent : UnityEvent<float> { }

[System.Serializable]
public class OnFragileCorruptionCardUsedEvent : UnityEvent<float> { }

