using System;
using ObjCRuntime;

[assembly: LinkWith ("libTwitterCore.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, Frameworks = "Security CoreData", SmartLink = true, ForceLoad = true)]
