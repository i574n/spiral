defmodule Spiral.Kino.Toolchain do
  @workspace Path.expand("../../../../compiler/tmp", __DIR__)

  @spec workspace(keyword()) :: String.t()
  def workspace(opts) do
    opts[:workspace] || System.get_env("SPIRAL_WORKSPACE_ROOT") || @workspace
  end

  @spec package_dir(keyword()) :: String.t()
  def package_dir(opts) do
    opts[:package_dir] || System.get_env("SPIRAL_COMPILER_PACKAGE_DIR") ||
      Path.join(Spiral.Kino.polyglot_root(opts), "deps/The-Spiral-Language/VS Code Plugin")
  end

  @spec compiler_dll(keyword()) :: String.t()
  def compiler_dll(opts) do
    opts[:compiler_dll] || System.get_env("SPIRAL_COMPILER_DLL") ||
      Path.join(
        cache_dir(),
        "bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll"
      )
  end

  @spec dotnet(keyword()) :: String.t() | nil
  def dotnet(opts) do
    opts[:dotnet] || System.get_env("SPIRAL_DOTNET") || bundled_dotnet() ||
      System.find_executable("dotnet")
  end

  @spec rustc(keyword()) :: String.t() | nil
  def rustc(opts) do
    opts[:rustc_bin] || System.get_env("SPIRAL_RUSTC") || System.find_executable("rustc")
  end

  @spec spiral(keyword()) :: String.t() | nil
  def spiral(opts) do
    opts[:spiral] || System.get_env("SPIRAL_EXE") || default_spiral()
  end

  @spec python(keyword()) :: String.t() | nil
  def python(opts) do
    opts[:python] || System.get_env("SPIRAL_PYTHON") || System.find_executable("python") ||
      System.find_executable("python3")
  end

  @spec lua(keyword()) :: String.t() | nil
  def lua(opts) do
    opts[:lua] || System.get_env("SPIRAL_LUA") || System.find_executable("lua")
  end

  @spec node(keyword()) :: String.t() | nil
  def node(opts) do
    opts[:node] || System.get_env("SPIRAL_NODE") || System.find_executable("node")
  end

  @spec pwsh(keyword()) :: String.t() | nil
  def pwsh(opts) do
    opts[:pwsh] || System.get_env("SPIRAL_PWSH") || System.find_executable("pwsh")
  end

  @spec cc(keyword()) :: String.t() | nil
  def cc(opts) do
    opts[:cc] || System.get_env("SPIRAL_CC") || System.find_executable("gcc") ||
      System.find_executable("clang") || System.find_executable("cl")
  end

  @spec dcc(keyword()) :: String.t() | nil
  def dcc(opts) do
    opts[:dcc] || System.get_env("SPIRAL_DCC") || System.find_executable("dcc32") ||
      System.find_executable("dcc64")
  end

  defp default_spiral do
    base = Path.expand("../../../../../workspace/target/release/spiral", __DIR__)
    Enum.find([base <> ".exe", base], &File.regular?/1)
  end

  defp bundled_dotnet do
    base = Path.join(cache_dir(), "toolchains/dotnet")
    Enum.find([Path.join(base, "dotnet.exe"), Path.join(base, "dotnet")], &File.regular?/1)
  end

  defp cache_dir do
    System.get_env("SPIRAL_BIN_CACHE_DIR") ||
      case System.get_env("LOCALAPPDATA") do
        nil -> Path.join(System.user_home!(), ".cache/spiral-bin")
        local -> Path.join(local, "spiral-bin")
      end
  end
end
