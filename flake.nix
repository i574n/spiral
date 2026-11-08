{
  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    rust-overlay.url = "github:oxalica/rust-overlay";
    rust-overlay.inputs.nixpkgs.follows = "nixpkgs";
    zig-overlay.url = "github:mitchellh/zig-overlay";
    zig-overlay.inputs.nixpkgs.follows = "nixpkgs";
  };

  outputs = { nixpkgs, rust-overlay, zig-overlay, ... }:
    let
      system = "x86_64-linux";
      pkgs = import nixpkgs { inherit system; overlays = [ rust-overlay.overlays.default ]; };
      beam = pkgs.beam.packages.erlang_29;
      rust = pkgs.rust-bin.nightly."2026-11-05".default.override {
        extensions = [ "clippy" "rust-src" "rustfmt" ];
        targets = [ "wasm32-unknown-unknown" ];
      };
      zig = zig-overlay.packages.${system}."0.17.0";
    in {
      devShells.${system}.default = pkgs.mkShell {
        packages = [
          pkgs.dotnet-sdk_9
          pkgs.python312
          beam.erlang
          beam.elixir_1_20
          beam.rebar3
          pkgs.gleam
          pkgs.bun
          pkgs.powershell
          rust
          zig
        ];
      };
    };
}
