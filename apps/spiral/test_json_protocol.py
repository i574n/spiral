"""Run against a rebuilt Spiral CLI: python test_json_protocol.py <spiral executable>.

Uses real child Python processes. No compiler, GPU, or package installation is needed.
"""
import json
import os
from pathlib import Path
import subprocess
import sys
import tempfile
import unittest


CLI = Path(sys.argv.pop(1)).resolve()
ROOT = Path(__file__).resolve().parents[2]


class JsonProtocol(unittest.TestCase):
    def run_child(self, source, level="Info"):
        with tempfile.TemporaryDirectory(prefix="spiral json ü ") as folder:
            script = Path(folder) / "child with spaces.py"
            script.write_text(source, encoding="utf-8")
            return subprocess.run(
                [str(CLI), "cuda", "--py-path", str(script)],
                cwd=ROOT,
                env={**os.environ, "SPIRAL_JSON": "1", "TRACE_LEVEL": level},
                capture_output=True,
                encoding="utf-8",
                errors="replace",
                timeout=30,
            )

    def test_success_is_one_json_document_at_every_trace_level(self):
        for level in ("Verbose", "Debug", "Info", "Warning", "Critical"):
            with self.subTest(level=level):
                result = self.run_child('print("child output: \\\"quoted\\\"")\n', level)
                self.assertEqual(result.returncode, 0, result.stderr)
                envelope = json.loads(result.stdout)
                payload = json.loads(envelope["command_result"])
                self.assertEqual(payload["extension"], "py")
                self.assertIn('child output: "quoted"', payload["output"])
                self.assertTrue(payload["code"])

    def test_child_exception_is_a_failure_with_original_diagnostic(self):
        result = self.run_child('raise RuntimeError("protocol-child-failure")\n')
        self.assertNotEqual(result.returncode, 0)
        self.assertIn("protocol-child-failure", result.stdout + result.stderr)
        self.assertNotIn('"command_result"', result.stdout)
        self.assertNotIn("Invalid JSON", result.stdout + result.stderr)

    def test_cuda_driver_failure_is_not_reported_as_success(self):
        result = self.run_child(
            'raise RuntimeError("cupy_backends.cuda.api.runtime.CUDARuntimeError: '
            'cudaErrorInsufficientDriver")\n'
        )
        self.assertNotEqual(result.returncode, 0)
        self.assertIn("cudaErrorInsufficientDriver", result.stdout + result.stderr)

    def test_rust_build_failure_is_a_failure_with_cargo_diagnostic(self):
        # `spiral rust` used to trace the cargo error and still exit 0 with an empty result.
        with tempfile.TemporaryDirectory(prefix="spiral json rust ") as folder:
            source = Path(folder) / "main.rs"
            source.write_text('fn main() { let _x: i32 = "rust-protocol-failure"; }\n', encoding="utf-8")
            result = subprocess.run(
                [str(CLI), "rust", "--rs-path", str(source)],
                cwd=ROOT,
                env={**os.environ, "SPIRAL_JSON": "1", "TRACE_LEVEL": "Info"},
                capture_output=True,
                encoding="utf-8",
                errors="replace",
                timeout=600,
            )
        # A clean exit 1, not a panic=abort crash (0xC0000409 on Windows).
        self.assertEqual(result.returncode, 1, result.stderr)
        self.assertIn("spiral.process_rust / error", result.stdout + result.stderr)
        self.assertIn("rust-protocol-failure", result.stdout + result.stderr)
        self.assertNotIn('"extension"', result.stdout)


if __name__ == "__main__":
    unittest.main()
