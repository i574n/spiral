installed() { [ "$(dpkg-query -W -f='${Status}' "$1" 2>/dev/null)" = "install ok installed" ]; }

if [ "$(id -u)" = "0" ]; then
    if ! installed build-essential || ! installed curl || ! installed unzip; then
        apt-get update
        apt-get install -y build-essential curl unzip
    fi
else
    rustup_path="$HOME/.cargo/bin/rustup"
    if [ ! -x "$rustup_path" ]; then
        curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh -s -- -y --default-toolchain none
    fi
    "$rustup_path" toolchain install nightly-2025-11-01 --profile minimal
fi
