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

- Used `System.ServiceProcess.ServiceController` for service management.
- Used `quser` command output parsing for retrieving Remote Desktop sessions.
- Focused on simplicity and clear UI design with basic data-binding.
- Requires administrative privileges to start/stop services.

## Build and Run Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/NethmiKaumudi/SystemMonitorApp.git
2. Open the solution SystemMonitorApp.sln in Visual Studio 2022.

3. Build the solution (ensure you have .NET 8 SDK installed).

4 .Run the application.

5. For service start/stop functionality, run Visual Studio as Administrator.

