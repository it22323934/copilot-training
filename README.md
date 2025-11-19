# AccelerateDevGHCopilot

## Description
AccelerateDevGHCopilot is a .NET-based application designed to manage and streamline library operations. It provides a modular architecture with core application logic, infrastructure support, and a console interface for user interaction.

## Project Structure
- `src/`
  - `Library.ApplicationCore/`
    - `Entities/`
    - `Enums/`
    - `Interfaces/`
    - `Services/`
  - `Library.Console/`
    - `appSettings.json`
    - `CommonActions.cs`
    - `ConsoleApp.cs`
    - `ConsoleState.cs`
    - `Program.cs`
    - `Json/`
  - `Library.Infrastructure/`
    - `Data/`
- `tests/`
  - `UnitTests/`
    - `LoanFactory.cs`
    - `PatronFactory.cs`
    - `ApplicationCore/`

## Key Classes and Interfaces
- **Library.ApplicationCore**
  - `Entities/`: Contains domain models representing core entities of the library system.
  - `Interfaces/`: Defines contracts for services and repositories.
  - `Services/`: Implements business logic for library operations.
- **Library.Console**
  - `ConsoleApp.cs`: Entry point for the console application.
  - `CommonActions.cs`: Contains reusable actions for the console interface.
  - `ConsoleState.cs`: Manages the state of the console application.
- **Library.Infrastructure**
  - `Data/`: Handles data access and persistence logic.

## Usage
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the solution file `AccelerateDevGHCopilot.sln` in Visual Studio.
3. Build the solution to restore dependencies and compile the project.
4. Run the console application by setting `Library.Console` as the startup project.

## License
This project is licensed under the MIT License. See the LICENSE file for details.