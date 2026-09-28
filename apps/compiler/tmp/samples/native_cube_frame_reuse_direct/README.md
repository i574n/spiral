# Direct Cube frame reuse authority

This source-real authority allocates one 160 by 44 dynamic frame before a bounded three-iteration rotation loop. Every iteration clears all 7040 cells, redraws the three projected cube markers, rebuilds the complete 7083-byte text and reproduces spatial checksums 45702, 43786 and 43631.

C, Rust and Delphi compile and return 42. The retained snapshots prove one backing frame allocation, one final frame drop and one clear-loop body. Portable calls may create bounded reference-counted handles, but no new frame storage is allocated inside the loop.

Terminal IO, sleeping and interactive animation remain outside this authority.
