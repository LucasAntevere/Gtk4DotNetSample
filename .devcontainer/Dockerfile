FROM mcr.microsoft.com/devcontainers/dotnet:10.0

RUN --mount=type=cache,target=/var/cache/apt,sharing=locked
RUN --mount=type=cache,target=/var/lib/apt,sharing=locked
RUN --mount=type=cache,target=/var/lib/flatpak,sharing=locked
RUN --mount=type=cache,target=/home/vscode/.local/share/,sharing=locked

RUN apt-get update
RUN apt-get install -y libgtk-4-dev libadwaita-1-dev flatpak flatpak-builder dbus git && rm -rf /var/lib/apt/lists/*

# Install ACT for running Github Actions locally
RUN curl --proto '=https' --tlsv1.2 -sSf https://raw.githubusercontent.com/nektos/act/master/install.sh | bash