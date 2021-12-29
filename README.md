# Sriptable Object Architecture

A simple system that makes use of *Scriptable Objects* to connect different classes. This leads to a cleaner and more reusable code.

## Latest Changes

### Added
- A stack trace for channel calls
- An icon for channel scriptable objects
- Added a changelog

### Changed
- Raise event button is now active only in play mode

## Install to Unity

Package Link for latest version, [v1.2.0](https://github.com/danielrusnac/unity-so-architecture-package/releases/tag/v1.2.0)
```
https://github.com/danielrusnac/unity-so-architecture-package.git?path=SO Architecture/Assets/SOArchitecture#v1.2.0
```

To get a specific verion of the package, go to releases and copy the "Package Link".

## Usage

1. Create a channel scriptable objcte *Create Asset/Channels/Channel Type*.
2. Add a field to your class for the created channel.
3. Register the callback.
4. Call **Raise** on the channel.
