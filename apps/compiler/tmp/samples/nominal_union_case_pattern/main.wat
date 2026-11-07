(module
  (import "wasi_snapshot_preview1" "proc_exit" (func $proc_exit (param i32)))
  (memory (export "memory") 2)
  (global $hp (mut i32) (i32.const 80))
  (func $spiralMain (result i32)
    (local $v0 i32)
    (local $v2 i32)
    (local $t2 i32)
    (local.set $v0 (i32.const 72))
    (local.set $t2 (i32.load (local.get $v0)))
    (if (i32.eq (local.get $t2) (i32.const 1))
        (then
            (local.set $v2 (i32.const 0))
        )
        (else
    (if (i32.eq (local.get $t2) (i32.const 0))
        (then
            (local.set $v2 (i32.const 1))
        )
        (else
    (unreachable)
        ))
        ))
    (if (local.get $v2)
        (then
            (return (i32.const 0))
        )
        (else
            (return (i32.const 1))
        ))
    (unreachable)
  )
  (data (i32.const 72) "\00\00\00\00")
  (func $_start (export "_start")
    (call $proc_exit (call $spiralMain)))
)
