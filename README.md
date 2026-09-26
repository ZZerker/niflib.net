# niflib.net
C# .NET Managed Library Handling NIF (NetImmerse/GameBryo game engine) file format for 3D Meshes / Models

## This fork

Fork of [dol-leodagan/niflib.net](https://github.com/dol-leodagan/niflib.net), modernized for [DAoC MapCreator](https://github.com/ZZerker/DAoC-MapCreator), which uses it as a git submodule.

- Targets .NET 10 (SDK-style project), was .NET Framework 4.0
- Math types are `System.Numerics` (`Vector2/3/4`, `Matrix4x4`, `Quaternion`) plus the library's own `Color3` and `Color4`. The SharpDX, OpenTK and MonoGame build variants are gone.
- No NuGet packages or other dependencies
- Parsing is unchanged: every model MapCreator converts gives byte-identical output to the original `Niflib.SharpDX.dll`

## Build

```
dotnet build Niflib.csproj -c Release
```

## Origin

This library is a Decompiled source code from an old Managed NIF Library, inspired by Niftool's Niflib, shared by an Anonymous developper of the Dawn Of Light project, who have lost the source tree...

## See

Niftools repository for Niflib : https://github.com/niftools/niflib

Most niflib.net Logic and Object Naming is mirrored from Niftools source code reimplemented in C#.

Niftools repository for NIF file format XML Description : https://github.com/niftools/nifxml

This is the Bible for understanding how to build an Object from a NIF file stream.

## License

GNU General Public License v2, see `LICENSE`.
