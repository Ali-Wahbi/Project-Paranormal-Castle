using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClockHandlerSingleton
{
    //  a singleton for handling the activation of the handlers
    //  so the player doesnot click on multible one at the same time
    public static bool isActivated = true;

}
