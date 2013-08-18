using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libZSDK_API.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
