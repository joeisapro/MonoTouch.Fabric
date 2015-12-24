using System;
using ObjCRuntime;

[assembly: LinkWith ("libMoPub.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, Frameworks = "AVFoundation", SmartLink = true, ForceLoad = true)]
