(module
  (import "wasi_snapshot_preview1" "proc_exit" (func $proc_exit (param i32)))
  (memory (export "memory") 2)
  (global $hp (mut i32) (i32.const 104))
  (func $spiralMain (result i32)
    (local $v0 i32)
    (local $v8 i32)
    (local $t2 i32)
    (local $v16 i32)
    (local $t4 i32)
    (local $v17 i32)
    (local $v18 i32)
    (local $t7 i32)
    (local $v19 i32)
    (local $v21 i32)
    (local $t10 i32)
    (local $v23 i32)
    (local $t12 i32)
    (local $v24 i32)
    (local $v25 i32)
    (local $v27 i32)
    (local $t16 i32)
    (local $v28 i32)
    (local $v29 i32)
    (local $v30 i32)
    (local.set $v0 (i32.const 72))
    (local.set $t2 (i32.load (local.get $v0)))
    (if (i32.eq (local.get $t2) (i32.const 1))
        (then
            (local.set $v8 (i32.const 80))
        )
        (else
    (if (i32.eq (local.get $t2) (i32.const 0))
        (then
            (local.set $v8 (i32.const 88))
        )
        (else
    (if (i32.eq (local.get $t2) (i32.const 2))
        (then
            (local.set $v8 (i32.const 96))
        )
        (else
    (if (i32.eq (local.get $t2) (i32.const 3))
        (then
            (local.set $v8 (i32.const 72))
        )
        (else
    (unreachable)
        ))
        ))
        ))
        ))
    (local.set $t4 (i32.load (local.get $v8)))
    (if (i32.eq (local.get $t4) (i32.const 1))
        (then
            (local.set $v16 (i32.const 80))
        )
        (else
    (if (i32.eq (local.get $t4) (i32.const 0))
        (then
            (local.set $v16 (i32.const 88))
        )
        (else
    (if (i32.eq (local.get $t4) (i32.const 2))
        (then
            (local.set $v16 (i32.const 96))
        )
        (else
    (if (i32.eq (local.get $t4) (i32.const 3))
        (then
            (local.set $v16 (i32.const 72))
        )
        (else
    (unreachable)
        ))
        ))
        ))
        ))
    (local.set $v17 (i32.const 80))
    (local.set $t7 (i32.load (local.get $v16)))
    (if (i32.ne (local.get $t7) (i32.load (local.get $v17))) (then (local.set $t7 (i32.const -1))))
    (if (i32.eq (local.get $t7) (i32.const 1))
        (then
            (local.set $v18 (i32.const 1))
        )
        (else
    (if (i32.eq (local.get $t7) (i32.const 0))
        (then
            (local.set $v18 (i32.const 1))
        )
        (else
    (if (i32.eq (local.get $t7) (i32.const 2))
        (then
            (local.set $v18 (i32.const 1))
        )
        (else
    (if (i32.eq (local.get $t7) (i32.const 3))
        (then
            (local.set $v18 (i32.const 1))
        )
        (else
    (local.set $v18 (i32.const 0))
        ))
        ))
        ))
        ))
    (if (local.get $v18)
        (then
            (local.set $v19 (i32.const 100))
        )
        (else
            (local.set $v19 (i32.const 0))
        ))
    (local.set $t10 (i32.load (local.get $v0)))
    (if (i32.eq (local.get $t10) (i32.const 1))
        (then
            (local.set $v21 (i32.const 2))
        )
        (else
    (if (i32.eq (local.get $t10) (i32.const 0))
        (then
            (local.set $v21 (i32.const 1))
        )
        (else
    (local.set $v21 (i32.const 7))
        ))
        ))
    (local.set $t12 (i32.load (local.get $v8)))
    (if (i32.eq (local.get $t12) (i32.const 1))
        (then
            (local.set $v23 (i32.const 2))
        )
        (else
    (if (i32.eq (local.get $t12) (i32.const 0))
        (then
            (local.set $v23 (i32.const 1))
        )
        (else
    (local.set $v23 (i32.const 7))
        ))
        ))
    (local.set $v24 (i32.mul (local.get $v23) (i32.const 3)))
    (local.set $v25 (i32.add (local.get $v21) (local.get $v24)))
    (local.set $t16 (i32.load (local.get $v16)))
    (if (i32.eq (local.get $t16) (i32.const 1))
        (then
            (local.set $v27 (i32.const 2))
        )
        (else
    (if (i32.eq (local.get $t16) (i32.const 0))
        (then
            (local.set $v27 (i32.const 1))
        )
        (else
    (local.set $v27 (i32.const 7))
        ))
        ))
    (local.set $v28 (i32.mul (local.get $v27) (i32.const 9)))
    (local.set $v29 (i32.add (local.get $v25) (local.get $v28)))
    (local.set $v30 (i32.add (local.get $v29) (local.get $v19)))
    (return (local.get $v30))
    (unreachable)
  )
  (data (i32.const 72) "\00\00\00\00")
  (data (i32.const 80) "\02\00\00\00")
  (data (i32.const 88) "\01\00\00\00")
  (data (i32.const 96) "\03\00\00\00")
  (func $_start (export "_start")
    (call $proc_exit (call $spiralMain)))
)
