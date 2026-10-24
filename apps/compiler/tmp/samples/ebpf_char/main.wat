(module
  (import "wasi_snapshot_preview1" "proc_exit" (func $proc_exit (param i32)))
  (memory (export "memory") 2)
  (global $hp (mut i32) (i32.const 72))
  (func $spiralMain (result i32)
    (local $v0 i32)
    (local $v1 i32)
    (local $v2 i32)
    (local $v3 i32)
    (local $v4 i32)
    (local.set $v0 (i32.const 65))
    (local.set $v1 (i32.const 66))
    (local.set $v2 (i32.eq (local.get $v0) (i32.const 65)))
    (if (local.get $v2)
        (then
            (local.set $v3 (i32.eq (local.get $v1) (i32.const 66)))
            (if (local.get $v3)
                (then
                    (local.set $v4 (i32.eq (local.get $v0) (local.get $v1)))
                    (if (local.get $v4)
                        (then
                            (return (i32.const 2))
                        )
                        (else
                            (return (i32.const 0))
                        ))
                )
                (else
                    (return (i32.const 3))
                ))
        )
        (else
            (return (i32.const 1))
        ))
    (unreachable)
  )
  (func $_start (export "_start")
    (call $proc_exit (call $spiralMain)))
)
