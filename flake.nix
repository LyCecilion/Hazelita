{
  description = "Development environment for Hazelita";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
  };

  outputs = { nixpkgs, ... }:
    let
      systems = [
        "x86_64-linux"
        "aarch64-linux"
      ];

      forAllSystems = nixpkgs.lib.genAttrs systems;
    in
    {
      devShells = forAllSystems (system:
        let
          pkgs = import nixpkgs { inherit system; };
          dotnet = pkgs.dotnet-sdk_10;
        in
        {
          default = pkgs.mkShell {
            packages = with pkgs; [
              dotnet
              clang
              lld
              pkg-config
              zlib
              openssl
              icu
            ];

            DOTNET_ROOT = "${dotnet}";
            DOTNET_NOLOGO = "1";
            DOTNET_SKIP_FIRST_TIME_EXPERIENCE = "1";
            LD_LIBRARY_PATH = pkgs.lib.makeLibraryPath [
              pkgs.zlib
              pkgs.openssl
              pkgs.icu
              pkgs.stdenv.cc.cc.lib
            ];
            NIX_LDFLAGS = "-L${pkgs.zlib}/lib";

            shellHook = ''
              export DOTNET_CLI_HOME="''${DOTNET_CLI_HOME:-$PWD/.dotnet}"
              export NUGET_PACKAGES="''${NUGET_PACKAGES:-$PWD/.nuget/packages}"

              mkdir -p "$DOTNET_CLI_HOME" "$NUGET_PACKAGES"
            '';
          };
        });
    };
}
