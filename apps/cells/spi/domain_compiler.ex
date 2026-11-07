defmodule Mix.Tasks.Compile.SpiralDomain do
  use Mix.Task.Compiler

  @impl Mix.Task.Compiler
  def run(_argv) do
    root = Path.expand("..", __DIR__)
    spi = Path.join(root, "spi")
    out = Path.join(root, "src/spiral_cells/domain.gleam")
    stamp = Path.join(root, "build/spiral_domain.inputs")
    digest = inputs_digest(spi)
    File.mkdir_p!(Path.dirname(out))

    unless File.regular?(out) and File.read(stamp) == {:ok, digest} do
      compile_spiral(Path.join(spi, "main.spi"), out, root)
      File.mkdir_p!(Path.dirname(stamp))
      File.write!(stamp, digest)
    end

    if gleam_stale?(root), do: gleam_build(root)
    {:ok, []}
  end

  defp inputs_digest(spi) do
    sources = Enum.sort(Path.wildcard(Path.join(spi, "*.spi"))) ++ [Path.join(spi, "package.spiproj")]
    own = Enum.map(sources, &[Path.basename(&1), 0, File.read!(&1), 0])
    packages = Enum.map(package_sources(spi), &[&1, 0, File.read!(&1), 0])
    :crypto.hash(:sha256, [own, packages]) |> Base.encode16()
  end

  defp package_sources(spi) do
    linked =
      for line <- String.split(File.read!(Path.join(spi, "package.spiproj")), "\n"),
          dir = line |> String.trim() |> String.trim_trailing("-"),
          String.starts_with?(dir, ".."),
          do: Path.expand(dir, spi)

    Enum.flat_map([Path.expand("../../../lib/spiral", spi) | linked], fn dir ->
      Enum.sort(Path.wildcard(Path.join(dir, "*.spi")) ++ Path.wildcard(Path.join(dir, "*.spiproj")))
    end)
  end

  defp gleam_stale?(root) do
    beams = Path.wildcard(Path.join(root, "build/dev/erlang/spiral_cells/ebin/*.beam"))
    sources = Path.wildcard(Path.join(root, "src/**/*.gleam")) ++ Enum.map(["gleam.toml", "manifest.toml"], &Path.join(root, &1))

    case beams do
      [] ->
        true

      _ ->
        built = beams |> Enum.map(&File.stat!(&1, time: :posix).mtime) |> Enum.min()
        Enum.any?(sources, fn path -> File.exists?(path) and File.stat!(path, time: :posix).mtime > built end)
    end
  end
  defp compile_spiral(entry, out, root) do
    dotnet = dotnet()
    dll = compiler_dll()

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

  defp compiler_dll, do: System.get_env("SPIRAL_COMPILER_DLL") || Path.join(cache(), "bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll")

  defp core_package_dir(root), do: Path.expand("../../deps/The-Spiral-Language/VS Code Plugin", root)

  defp gleam_build(root) do
    scoop = Path.join(System.user_home!(), "scoop/apps")
    erlang = Path.join(scoop, "erlang/current/bin")

    gleam =
      System.get_env("SPIRAL_GLEAM") ||
        Enum.find([Path.join(scoop, "gleam/current/gleam.exe")], &File.regular?/1) ||
        System.find_executable("gleam") ||
        Mix.raise("spiral_domain: gleam was not found (set SPIRAL_GLEAM)")

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

  defp cache do
    System.get_env("SPIRAL_BIN_CACHE_DIR") ||
      case System.get_env("LOCALAPPDATA") do
        nil -> Path.join(System.user_home!(), ".cache/spiral-bin")
        local -> Path.join(local, "spiral-bin")
      end
  end
end
