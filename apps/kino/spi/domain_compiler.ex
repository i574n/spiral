defmodule Mix.Tasks.Compile.SpiralDomain do
  use Mix.Task.Compiler

  # Portable (Windows dev box and Linux CI): every tool comes from an env override, then the spiral-bin cache / scoop
  # install this machine uses, then PATH.
  #   SPIRAL_DOTNET, SPIRAL_COMPILER_DLL, SPIRAL_COMPILER_PACKAGE_DIR, SPIRAL_BIN_CACHE_DIR, SPIRAL_GLEAM

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
    dotnet = dotnet()
    dll = System.get_env("SPIRAL_COMPILER_DLL") || Path.join(cache(), "bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll")

    unless dotnet, do: Mix.raise("spiral_domain: dotnet was not found (set SPIRAL_DOTNET)")
    unless File.regular?(dll), do: Mix.raise("spiral_domain: the Spiral compiler was not found at #{dll} (set SPIRAL_COMPILER_DLL)")

    env = [
      {"DOTNET_NOLOGO", "1"},
      {"DOTNET_CLI_TELEMETRY_OPTOUT", "1"},
      {"SPIRAL_WORKSPACE_ROOT", System.get_env("SPIRAL_WORKSPACE_ROOT") || Path.expand("../compiler/tmp", root)},
      {"SPIRAL_COMPILER_PACKAGE_DIR", System.get_env("SPIRAL_COMPILER_PACKAGE_DIR") || core_package_dir(root)}
    ]

    env = if bundled?(dotnet), do: [{"DOTNET_ROOT", Path.dirname(dotnet)} | env], else: env

    {output, status} =
      System.cmd(dotnet, [dll, "--backend", "Gleam", entry, out],
        env: env,
        stderr_to_stdout: true
      )

    if status != 0, do: Mix.raise(output)
  end

  # The `|core-` package: the fork spiral's scripts/init.ps1 clones (spiral/deps/The-Spiral-Language), else polyglot's
  # clone of it (as Spiral.Kino.Toolchain.default_package_dir/0, which is not compiled yet when this runs).
  defp core_package_dir(root) do
    candidates =
      Enum.map(["../../deps", "../../../polyglot/deps"], &Path.expand(&1 <> "/The-Spiral-Language/VS Code Plugin", root))

    Enum.find(candidates, &File.regular?(Path.join(&1, "core/package.spiproj"))) || hd(candidates)
  end

  defp gleam_build(root) do
    scoop = Path.join(System.user_home!(), "scoop/apps")
    erlang = Path.join(scoop, "erlang/current/bin")

    gleam =
      System.get_env("SPIRAL_GLEAM") ||
        Enum.find([Path.join(scoop, "gleam/current/gleam.exe")], &File.regular?/1) ||
        System.find_executable("gleam") ||
        Mix.raise("spiral_domain: gleam was not found (set SPIRAL_GLEAM)")

    # scoop's OTP first: chocolatey's older OTP on PATH breaks gleam ("corrupt atom table").
    prefix = Enum.filter([erlang, Path.dirname(gleam)], &File.dir?/1)
    sep = if match?({:win32, _}, :os.type()), do: ";", else: ":"
    path = Enum.join(prefix ++ [System.get_env("PATH", "")], sep)

    {output, status} =
      System.cmd(gleam, ["build"], cd: root, env: [{"PATH", path}], stderr_to_stdout: true)

    if status != 0, do: Mix.raise(output)
  end

  defp dotnet do
    base = Path.join(cache(), "toolchains/dotnet")

    System.get_env("SPIRAL_DOTNET") ||
      Enum.find([Path.join(base, "dotnet.exe"), Path.join(base, "dotnet")], &File.regular?/1) ||
      System.find_executable("dotnet")
  end

  defp bundled?(dotnet), do: String.starts_with?(Path.expand(dotnet), Path.expand(Path.join(cache(), "toolchains")))

  # Same cache as Spiral.Kino.Toolchain: %LOCALAPPDATA%\spiral-bin on Windows, ~/.cache/spiral-bin elsewhere.
  defp cache do
    System.get_env("SPIRAL_BIN_CACHE_DIR") ||
      case System.get_env("LOCALAPPDATA") do
        nil -> Path.join(System.user_home!(), ".cache/spiral-bin")
        local -> Path.join(local, "spiral-bin")
      end
  end
end
