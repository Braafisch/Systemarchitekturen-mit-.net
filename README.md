# Systemarchitekturen mit .NET

## Projektaufbau

Dieses Projekt verwendet das neue plattformunabhängige [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), statt dem Windows exklusiven [.NET Framework](https://dotnet.microsoft.com/download/dotnet/5.0) (oft nur .NET genannt). Um den Einstieg zu erleichtern sind alle notwendigen Tools in einem vscode dev-container vorbereitet. Zum Loslegen wird lediglich [vscode](https://code.visualstudio.com/) und [Docker](https://www.docker.com/) benötigt. Mit der vscode Erweiterung [Remote - Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) (id: `ms-vscode-remote.remote-containers`) kann über das Aktionsmenü (`Ctrl` + `Shift` + `P`) die Aktion _>Remote-Containers: Reopen in Container_ gestartet werden, welches diese Arbeitsumgebung in einem vorbereiteten Docker Container öffnet. Die vorinstallierte Konsolenanwendung `dotnet` wird dann zum Kompilieren, Testen, Verwalten und Ausführen der Projekte verwendet.

```sh
cd aufgabe1
dotnet run
```

Mit `dotnet` können auch neue Projekte hinzugefügt und verwaltet werden. Dazu zunächst das Projekt im Projektordner erstellen:

```sh
mkdir mein-neues-projet
cd mein-neues-projekt
dotnet new console
# Erzeugt eine Konsolenanwendung, weitere Projekt-Templates lassen sich per 'dotnet new -l' auflisten.
```

Danach sollte das Projekt noch in die übergeordnete Solution (`.sln`) Datei eingetragen werden:

```sh
cd .. # zurück ins Hauptverzeichnis
dotnet sln add mein-neues-projekt
```
