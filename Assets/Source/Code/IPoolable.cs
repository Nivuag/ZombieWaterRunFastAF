using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable 
{ 
    ObjectsPoolComponent AssociatedPool { get; set; }
}
