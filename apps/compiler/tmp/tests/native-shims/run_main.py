"""Native-tier runner for `Python + Cuda` outputs (scripts/test.ps1 -Native, Python rows).

    python run_main.py <dir>/main.py

Loads the generated module without running its `__main__` block, calls `main()`, and exits with its result
when that is an int, so exit code + stdout compare with the C oracle the same way the Rust/Delphi rows do.
An uncaught exception exits 1 ("both failed" in the oracle rule). The caller sets PYTHONDONTWRITEBYTECODE=1
(no __pycache__ in samples/) and SPIRAL_CUDA=0 (deterministic CPU path).
"""
import os
import runpy
import sys


def main():
    path = os.path.abspath(sys.argv[1])
    sys.path.insert(0, os.path.dirname(path))
    namespace = runpy.run_path(path, run_name="spiral_native")
    result = namespace["main"]()
    sys.stdout.flush()
    sys.exit(result if isinstance(result, int) and not isinstance(result, bool) else 0)


if __name__ == "__main__":
    main()
