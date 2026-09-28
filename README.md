# niflib.net
C# .NET Managed Library Handling NIF (NetImmerse/GameBryo game engine) file format for 3D Meshes / Models

## This fork

Fork of [dol-leodagan/niflib.net](https://github.com/dol-leodagan/niflib.net), modernized for [DAoC MapCreator](https://github.com/ZZerker/DAoC-MapCreator), which uses it as a git submodule.

- Targets .NET 10 (SDK-style project), was .NET Framework 4.0
- Math types are `System.Numerics` (`Vector2/3/4`, `Matrix4x4`, `Quaternion`) plus the library's own `Color3` and `Color4`. The SharpDX, OpenTK and MonoGame build variants are gone.
- No NuGet packages or other dependencies
- Parsing is unchanged: every model MapCreator converts gives byte-identical output to the original `Niflib.SharpDX.dll`

## Build

Install the .NET 10 SDK, then build the solution:

```powershell
dotnet build Niflib.slnx -c Release
```

You can also build the project directly:

```powershell
dotnet build Niflib.csproj -c Release
```

## Source layout

Source files under `Niflib` are grouped by feature: core object types, file IO, scene graph, geometry, skinning, animation, rendering, particles, extra data, numerics, and traversal. Related data types, records, controllers, properties, textures, and effects stay with the feature that owns them.

Folders organize the source tree but do not define namespaces. Existing namespaces remain unchanged to preserve the public API and the reflection-based block loader. New files should be placed with the closest existing feature while following that namespace compatibility rule.

## Origin

This library is a Decompiled source code from an old Managed NIF Library, inspired by Niftool's Niflib, shared by an Anonymous developper of the Dawn Of Light project, who have lost the source tree...

## See

Niftools repository for Niflib : https://github.com/niftools/niflib

Most niflib.net Logic and Object Naming is mirrored from Niftools source code reimplemented in C#.

Niftools repository for NIF file format XML Description : https://github.com/niftools/nifxml

This is the Bible for understanding how to build an Object from a NIF file stream.

## License

GNU General Public License v2, see `LICENSE`.
