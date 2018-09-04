﻿using System;
namespace MyTimer
{
    public interface ILogger
    {
        void WriteLine(string message);
        void WriteLine(params string[] list);
        void Write(string message);
        string ReadLine();
    }
}
