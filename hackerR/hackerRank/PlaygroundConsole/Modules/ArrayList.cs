using System;
using System.Collections;

namespace PlaygroundConsole.Modules;

public class ArrayListImplementation
{
    public Array GenerateArrayList()
    {
        var arrList = new ArrayList();
        arrList.Add("abc");
        arrList.Add("yellow");

        return arrList.ToArray(typeof(string));
    }
}