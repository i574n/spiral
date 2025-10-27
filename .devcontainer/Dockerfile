FROM mcr.microsoft.com/vscode/devcontainers/universal:dev

USER root

RUN apt-get update && export DEBIAN_FRONTEND=noninteractive && apt-get -y install --no-install-recommends \
    powershell


RUN df -h
RUN apt-get remove -y '^dotnet-.*'
RUN df -h
RUN ls -al /usr/share/dotnet/sdk
RUN rm -rf /usr/share/dotnet/
RUN df -h


USER codespace
