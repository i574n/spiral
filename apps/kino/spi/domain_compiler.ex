defmodule Mix.Tasks.Compile.SpiralDomain do
  use Mix.Task.Compiler

  @impl Mix.Task.Compiler
  def run(_argv) do
    root = Path.expand("..", __DIR__)
    spi = Path.join(root, "spi")
    out = Path.join(root, "src/spiral_kino/domain.gleam")
    File.mkdir_p!(Path.dirname(out))
    if stale?(spi, out), do: compile_spiral(Path.join(spi, "main.spi"), out, root)
    gleam_build(root)
    {:ok, []}
  end

  defp stale?(spi, out) do
    sources = Path.wildcard(Path.join(spi, "*.spi")) ++ [Path.join(spi, "package.spiproj")]

    not File.regular?(out) or
      Enum.any?(sources, fn path -> File.stat!(path).mtime > File.stat!(out).mtime end)
  end

  defp compile_spiral(entry, out, root) do
    dotnet = Path.join(cache(), "toolchains/dotnet/dotnet.exe")
    dll = Path.join(cache(), "bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll")

    env = [
      {"DOTNET_ROOT", Path.dirname(dotnet)},
      {"DOTNET_NOLOGO", "1"},
      {"DOTNET_CLI_TELEMETRY_OPTOUT", "1"},
      {"SPIRAL_WORKSPACE_ROOT", Path.expand("../compiler/tmp", root)},
      {"SPIRAL_COMPILER_PACKAGE_DIR",
       Path.expand("../../../polyglot/deps/The-Spiral-Language/VS Code Plugin", root)}
    ]

    {output, status} =
      System.cmd(dotnet, [dll, "--backend", "Gleam", entry, out],
        env: env,
        stderr_to_stdout: true
      )

    if status != 0, do: Mix.raise(output)
  end

  defp gleam_build(root) do
    gleam = Path.join(System.user_home!(), "scoop/apps/gleam/current/gleam.exe")
    erlang = Path.join(System.user_home!(), "scoop/apps/erlang/current/bin")
    path = erlang <> ";" <> Path.dirname(gleam) <> ";" <> System.get_env("PATH", "")

    {output, status} =
      System.cmd(gleam, ["build"], cd: root, env: [{"PATH", path}], stderr_to_stdout: true)

    if status != 0, do: Mix.raise(output)
  end

  defp cache do
    System.get_env("SPIRAL_BIN_CACHE_DIR") ||
      Path.join(System.get_env("LOCALAPPDATA") || Path.join(System.user_home!(), "AppData/Local"), "spiral-bin")
  end
end
