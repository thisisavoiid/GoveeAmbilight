# GoveeAmbilight

**Ambilight effect for Govee lights driven by the average screen color.**

GoveeAmbilight is a small C# application that continuously captures the screen, calculates the average color, and sends it to a Govee light on the local network. The result is a simple ambilight-style effect that reacts to whatever is currently displayed on the monitor.

The project discovers Govee devices via UDP multicast, then streams color updates at a controlled rate.

---

## What is this?

- A lightweight ambilight solution for Govee smart lights
- Screen capture + average color calculation
- Local network discovery and control of Govee devices over UDP

---

## How it works

1. The application scans the local network for Govee devices using multicast.
2. Once a device is found, it starts capturing the screen.
3. The captured frame is heavily downscaled for performance.
4. The average RGB color of the downscaled image is calculated.
5. That color is sent to the Govee light as a `colorwc` command.
6. The process repeats at a fixed interval (~30 ms).

---

## Core Features

- **Automatic device discovery**  
  Uses Govee’s local UDP scan protocol (multicast).

- **Screen capture**  
  Captures the full primary screen and downscales it for speed.

- **Average color calculation**  
  Computes a single RGB value representing the current screen content.

- **Continuous color streaming**  
  Sends color updates to the light at a controlled rate.

- **Clean packet structure**  
  Request/response packages are modeled as simple C# records and classes.

---

## Requirements

- Windows
- .NET (compatible with the project’s target framework)
- A Govee light that supports local LAN control
- The light must be on the same network as the PC

---

## Building & Running

1. Open the solution in Visual Studio
2. Restore NuGet packages if needed
3. Build and run

The application will attempt to discover a Govee device on startup. If none is found, it exits. Once a device is found, it begins the ambilight loop.

---

## Project Structure (Core)

| Component                | Purpose                                      |
|--------------------------|----------------------------------------------|
| `GoveeAmbilightCore`     | Main application loop                        |
| `ScreenCapture`          | Captures and averages screen color           |
| `GoveeDevice`            | Represents a discovered light                |
| `GoveeDeviceScanner`     | Discovers devices via UDP multicast          |
| `GoveePackageSender`     | Sends and receives UDP packages              |
| `GoveeColor`             | Simple RGB color struct                      |
| Command Packages         | Scan + color request/response models         |

---

## Notes

- The current implementation targets the primary screen only.
- Color updates are rate-limited to avoid flooding the device.
- This project uses the local Govee LAN protocol and does not require the Govee cloud API.

---

## License

MIT License - see [LICENSE](LICENSE)
