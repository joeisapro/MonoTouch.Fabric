using System;
using ObjCRuntime;

[assembly: LinkWith("libTwitterKit.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, Frameworks = "CoreText Accounts Social QuartzCore", SmartLink = true, ForceLoad = true)]
