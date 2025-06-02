# SystemMonitorApp

## Overview

A simple Windows desktop application built with C# and WPF (.NET 8) that:

- Displays the status of Windows Services on the local machine.
- Shows currently logged-in Remote Desktop users.
- Allows starting and stopping Windows services via the UI.
- Demonstrates clean UI design and basic interaction.

## Features

- List Windows Services with:
  - Service Name
  - Display Name
  - Status (Running/Stopped)
- Start or stop selected Windows services.
- Display Remote Desktop sessions with:
  - Username
  - Session ID
  - Session state (Active/Disconnected)

## Framework

- Built using WPF with .NET 8.

## Assumptions and Decisions

- Used `.NET 8` with Windows Forms for the UI framework.
- Utilized `System.ServiceProcess.ServiceController` to manage and control Windows services.
- For retrieving Remote Desktop sessions, used the `Wtsapi32.dll` with `WTSEnumerateSessions` and `WTSQuerySessionInformation`.
- Basic data-binding and DataGridView were used for user-friendly display.
- Assumes the app is run with administrative privileges to control service status.
- Skips system and empty sessions (e.g., Session ID 0 and those without usernames).
- Focused on simplicity, readability, and clean UI design.


## Build and Run Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/NethmiKaumudi/SystemMonitorApp.git
2. Open the solution SystemMonitorApp.sln in Visual Studio 2022.

3. Build the solution (ensure you have .NET 8 SDK installed).

4. Run the application.

5. For service start/stop functionality, run Visual Studio as Administrator.

