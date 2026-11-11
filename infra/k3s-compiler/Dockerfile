ARG DOTNET_SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:11.0.100-rc.3@sha256:59d092a889fbad09c1a0b0c5dd072c6315125b0294a5cddfa48ec892f63b2ab3
ARG DOTNET_RUNTIME_IMAGE=mcr.microsoft.com/dotnet/runtime:11.0.0-rc.3@sha256:2484f5047d00a8f4554c6c68106b0e70e397ebbc6cf32bd28e768c1de23c8cd7

FROM ${DOTNET_SDK_IMAGE} AS build
WORKDIR /src
COPY spiral_compiler.fs ./
COPY runtime ./runtime
COPY tmp/compiler ./tmp/compiler
RUN dotnet publish tmp/compiler/host/SpiralCompiler.fsproj -c Release -p:SpiralCore=single-flight -o /app \
    && dotnet /app/SpiralCompiler.dll --capabilities | grep -qw server-tcp

FROM ${DOTNET_RUNTIME_IMAGE}
WORKDIR /app
COPY --from=build /app ./
USER $APP_UID
ENV HOME=/work/home \
    DOTNET_GCgen0size=0x4000000 \
    DOTNET_EnableDiagnostics=0
EXPOSE 7470
ENTRYPOINT ["dotnet", "/app/SpiralCompiler.dll"]
CMD ["--server-tcp", "/work/session/compiler"]
