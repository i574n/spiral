(module
  (import "wasi_snapshot_preview1" "proc_exit" (func $proc_exit (param i32)))
  (memory (export "memory") 2)
  (global $hp (mut i32) (i32.const 104))
  (func $score_0 (param $v0 i32) (result i32)
    (local $t0 i32)
    (local.set $t0 (i32.load (local.get $v0)))
    (if (i32.eq (local.get $t0) (i32.const 0))
        (then
            (return (i32.const 1))
        )
        (else
    (if (i32.eq (local.get $t0) (i32.const 3))
        (then
            (return (i32.const 4))
        )
        (else
    (if (i32.eq (local.get $t0) (i32.const 2))
        (then
            (return (i32.const 3))
        )
        (else
    (if (i32.eq (local.get $t0) (i32.const 1))
        (then
            (return (i32.const 2))
        )
        (else
    (unreachable)
        ))
        ))
        ))
        ))
    (unreachable)
  )
  (func $spiralMain (result i32)
    (local $v0 i32)
    (local $v1 i32)
    (local $v10 i32)
    (local $v3 i32)
    (local $v5 i32)
    (local $v11 i32)
    (local $v12 i32)
    (local.set $v0 (i32.const 3))
    (local.set $v1 (i32.eq (local.get $v0) (i32.const 0)))
    (if (local.get $v1)
        (then
            (local.set $v10 (i32.const 72))
        )
        (else
            (local.set $v3 (i32.eq (local.get $v0) (i32.const 1)))
            (if (local.get $v3)
                (then
                    (local.set $v10 (i32.const 80))
                )
                (else
                    (local.set $v5 (i32.eq (local.get $v0) (i32.const 2)))
                    (if (local.get $v5)
                        (then
                            (local.set $v10 (i32.const 88))
                        )
                        (else
                            (local.set $v10 (i32.const 96))
                        ))
                ))
        ))
    (local.set $v11 (call $score_0 (local.get $v10)))
    (local.set $v12 (i32.sub (local.get $v11) (i32.const 4)))
    (return (local.get $v12))
    (unreachable)
  )
  (data (i32.const 72) "\00\00\00\00")
  (data (i32.const 80) "\01\00\00\00")
  (data (i32.const 88) "\02\00\00\00")
  (data (i32.const 96) "\03\00\00\00")
  (func $_start (export "_start")
    (call $proc_exit (call $spiralMain)))
)
