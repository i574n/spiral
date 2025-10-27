FROM mcr.microsoft.com/vscode/devcontainers/universal:dev

USER root

RUN apt-get update && export DEBIAN_FRONTEND=noninteractive && apt-get -y install --no-install-recommends \
    powershell

RUN df -h

USER codespace
