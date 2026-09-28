# Const borrowed ABI buffers

This fixture creates two managed byte arrays, compares an equal three-byte prefix and an unequal four-byte payload through registered libc `memcmp`, then rereads both arrays. Rust uses immutable `RefCell` borrows; Delphi uses `const` dynamic-array parameters; C uses the bounded oracle shim. All three programs exit zero.