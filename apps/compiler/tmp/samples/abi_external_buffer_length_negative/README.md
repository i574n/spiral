# Mutable ABI length negative

This negative fixture passes a two-byte managed buffer to the registered libc `memset` adapter while requesting three bytes. C, Rust and Delphi must reject the call at runtime before writing beyond the buffer. The gate accepts only a nonzero native exit and retains the canonical residues as evidence of the bounds contract.